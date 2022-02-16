﻿using System;

namespace Cliargs
{
	public class CliArgsContainer: ICliArgsContainer
	{
        public CliArgsContainer() : this(new CliArgsFormat())
        {
        }

        public CliArgsContainer(CliArgsFormat format)
		{
			this.CliArgsRepository = new CliArgsRepository();
            this.Format = format;
		}

        public ICliArgsRepository CliArgsRepository { get; }
        public CliArgsFormat Format { get; }

        public T? GetValue<T>(string argName)
        {
            if (!CliArgsRepository.CliArgsInfos.ContainsKey(argName))
                return default;

            CliArg<T>? arg = this.CliArgsRepository.CliArgs[argName] as CliArg<T>;

            if (arg != null)
                return arg.Value;

            return default;
        }

        public void Register(CliArgsInfo info, ICliArgsValidationContext context)
        {
            this.CliArgsRepository.AddCliArgsInfo(info);
            this.CliArgsRepository.AddCliArgsValidationContext(info.Name, context);
        }
    }
}

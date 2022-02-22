using System;
namespace Cliargs
{
	public class DefaultContainerSetup: ICliArgsSetup
	{
		public DefaultContainerSetup()
		{
		}

        public void Configure(ICliArgsContainer container)
        {
            container.Register(
                CliArg.New<string>(CliArgsOptions.HelpArg.Name)
                .WithLongName(CliArgsOptions.HelpArg.LongName)
                .WithShortName(CliArgsOptions.HelpArg.ShortName)
                .NoRequiredValue()
                .AsOptional()
                .WithDescription("Show command line interface arguments help")
                .WithUsage($"{container.Format.ShortNamePrefix}{CliArgsOptions.HelpArg.ShortName}|{container.Format.LongNamePrefix}{CliArgsOptions.HelpArg.LongName}")
                );
        }
    }
}


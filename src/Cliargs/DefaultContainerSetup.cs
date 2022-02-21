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
                CliArg.New<string>("Help")
                .WithLongName("help")
                .WithShortName("h")
                .NoRequiredValue()
                .AsOptional()
                .WithDescription("Show command line interface arguments help")
                .WithUsage($"{container.Format.ShortNamePrefix}h|{container.Format.NamePrefix}help")
                );
        }
    }
}


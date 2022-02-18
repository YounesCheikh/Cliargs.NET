using System;
namespace Cliargs
{
	public class CliArgsBuilder: ICliArgsBuilder
	{
		public CliArgsBuilder()
		{

		}

        public TCliArgsContainer Build<TCliArgsContainer>(ICliArgsSetup setup) where TCliArgsContainer: ICliArgsContainer, new()
        {
            var container = new TCliArgsContainer();
            setup.Configure(container);

            var argsCollection = Environment.GetCommandLineArgs().Skip(1);

            var argInfos = container.CliArgsRepository.CliArgs.Values.Select(e=> e.Info).ToList();
            var mandatoryArgs = argInfos.Where(e => !e.Optional).ToList();

            var allMandatoryArgsAreHere = mandatoryArgs.All(a =>
                argsCollection.Contains($"{container.Format.NamePrefix}{a.Name}")
                || argsCollection.Contains($"{container.Format.ShortNamePrefix}{a.ShortName}")
            );

            if (!allMandatoryArgsAreHere)
                throw new Exception("Missing mandatory arguments");

            return container;
        }
    }
}


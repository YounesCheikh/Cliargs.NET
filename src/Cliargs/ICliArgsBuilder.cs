using System;
namespace Cliargs
{
	public interface ICliArgsBuilder
	{
		TCliArgsContainer Build<TCliArgsContainer>(ICliArgsSetup setup) where TCliArgsContainer : ICliArgsContainer, new();
	}
}


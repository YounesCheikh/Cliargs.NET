using System;

namespace Cliargs
{
	static class CliArgsValidator 
	{
        internal static IList<ICliArgsValidationResult> Validate(ICliArgsContainer container)
        {
            var containerInstance = container;
            var args = containerInstance.GetArgs().ToList();
            foreach (var arg in args)
            {
                var results = arg.Validate();
                if (!results.Any())
                    continue;

                return results.ToList();
                //foreach(var result in results)
                //{
                //    yield return result;
                //}
                //yield break;
            }

            return new List<ICliArgsValidationResult>();
        }

        
    }
}


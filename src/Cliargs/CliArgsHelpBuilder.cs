using System;
using System.Text;

namespace Cliargs
{
	public class CliArgsHelpBuilder: ICliArgsHelpBuilder
	{
		private int headerPadding;
		ICliArgsContainer _container;
		public CliArgsHelpBuilder(ICliArgsContainer container)
		{
			this._container = container;
		}

		public string Build()
        {
			headerPadding = _container.CliArgs.Values.Select(e => e.Info.LongName).Max(e => e.Length);
			headerPadding += _container.CliArgs.Values.Select(e => e.Info.ShortName).Max(e => e.Length);
			headerPadding += headerPadding < 15? 15 - headerPadding : 6;
			StringBuilder stringBuilder = new StringBuilder();

			stringBuilder.AppendLine();

			stringBuilder.AppendLine("Required arguments:");
			stringBuilder.AppendLine(BuildFor(a => !a.Info.Optional));

			stringBuilder.AppendLine("Optional arguments:");
			stringBuilder.AppendLine(BuildFor(a => a.Info.Optional));

			return stringBuilder.ToString();
		}

		private string BuildFor(Func<CliArg, bool> func)
        {
			StringBuilder stringBuilder = new StringBuilder();
			var format = _container.Format;
			var targetArgs = _container.CliArgs.Values.Where(func).ToList();
			foreach (var arg in targetArgs)
			{
				var info = arg.Info;
				var helpHeader = string.Empty;
				if (!string.IsNullOrWhiteSpace(info.ShortName) && !string.IsNullOrWhiteSpace(info.LongName))
				{
					helpHeader = $"{format.ShortNamePrefix}{info.ShortName}|{format.NamePrefix}{info.LongName}";
				}
				else if (!string.IsNullOrWhiteSpace(info.ShortName))
				{
					helpHeader = $"{format.ShortNamePrefix}{info.ShortName}|{format.NamePrefix}{info.Name}";
				}
				else if (!string.IsNullOrWhiteSpace(info.LongName))
				{
					helpHeader = $"{format.NamePrefix}{info.LongName}";
				}
				else
				{
					helpHeader = $"{format.NamePrefix}{info.Name}";
				}
				if(info.RequiresValue)
                {
					helpHeader = $"{helpHeader}{format.AssignationChar}<{info.Name}>";
                }

				stringBuilder.AppendLine(
					string.Format("  {0}   {1}", helpHeader.PadRight(headerPadding), info.Description)
					);
			}

			return stringBuilder.ToString();
		}
	}
}


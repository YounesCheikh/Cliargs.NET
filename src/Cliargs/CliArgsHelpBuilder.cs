using System;
using System.Linq;
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

		/// <summary>
		/// Build the help string
		/// </summary>
		/// <returns>The help string</returns>
		public string Build()
        {
			headerPadding = _container.CliArgs.Values
				.Select(e =>
				 string.Format("{0}{1}{2}", e.Info.RequiresValue ? e.Info.Name : "", e.Info.LongName, e.Info.ShortName).Length
				     )
				.Max();

			headerPadding += $"{_container.Format.AssignationChar}{_container.Format.LongNamePrefix}{_container.Format.ShortNamePrefix}< >|".Length;
			// headerPadding += headerPadding < 15? 15 - headerPadding : 6;
			headerPadding = Math.Max(headerPadding, 20);
			StringBuilder stringBuilder = new StringBuilder();

			stringBuilder.AppendLine();

			stringBuilder.AppendLine("Required arguments:");
			stringBuilder.AppendLine(BuildFor(a => !a.Info.Optional));

			stringBuilder.AppendLine("Optional arguments:");
			stringBuilder.AppendLine(BuildFor(a => a.Info.Optional));

			return stringBuilder.ToString();
		}

		/// <summary>
		/// Build help string line for a specific argument
		/// </summary>
		/// <param name="func">The argument func</param>
		/// <returns>The help string</returns>
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
					helpHeader = $"{format.ShortNamePrefix}{info.ShortName}|{format.LongNamePrefix}{info.LongName}";
				}
				else if (!string.IsNullOrWhiteSpace(info.ShortName))
				{
					helpHeader = $"{format.ShortNamePrefix}{info.ShortName}|{format.LongNamePrefix}{info.Name}";
				}
				else if (!string.IsNullOrWhiteSpace(info.LongName))
				{
					helpHeader = $"{format.LongNamePrefix}{info.LongName}";
				}
				else
				{
					helpHeader = $"{format.LongNamePrefix}{info.Name}";
				}
				if(info.RequiresValue)
                {
					helpHeader = $"{helpHeader}{format.AssignationChar}<{info.Name}>";
                }

				stringBuilder.AppendLine(
					string.Format("  {0}   {1}", helpHeader.PadRight(headerPadding), info.Description)
					);
				if(arg.Info.Optional && arg.Info.HasDefaultValue)  {
					stringBuilder.AppendLine(
					string.Format("  {0}   {1}", string.Empty.PadRight(headerPadding), $"Default value: {arg.GetDefaultValue()}")
					);
					// stringBuilder.AppendLine();
				}
			}

			return stringBuilder.ToString();
		}
	}
}


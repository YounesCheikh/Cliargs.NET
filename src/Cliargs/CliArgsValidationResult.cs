using System;
using System.Text;

namespace Cliargs
{
	public class CliArgsValidationResult: ICliArgsValidationResult
	{
		public CliArgsValidationResult(ICliArgsValidationRule rule, CliArgsInfo info, bool isValid)
		{
			ArgumentNullException.ThrowIfNull(rule);
			ArgumentNullException.ThrowIfNull(info);

			_rule = rule;
			_info = info;
			IsValid = isValid;
		}

		private ICliArgsValidationRule _rule;
		private CliArgsInfo _info;

        public bool IsValid { get; private set; }

		public string Usage => _info.Usage;

		public string ValidationError => _rule.GetValidationError();

		public string ArgName => _info.Name;

		public string RuleName => _rule.GetType().GetNameWithoutGenericArity();

		public override string ToString()
        {
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.AppendLine($"Error: Failed to validate Arugment {ArgName} with rule {RuleName}");
			stringBuilder.AppendLine($"\"{ValidationError}\"");
			stringBuilder.AppendLine($"Example usage: ");
			stringBuilder.AppendLine(Usage);
			return stringBuilder.ToString();
		}
    }
}


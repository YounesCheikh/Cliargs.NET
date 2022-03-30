using System;
using System.Text.RegularExpressions;
using System.Linq;
namespace Cliargs
{
	public class ArgNamesGenerator: IArgNamesGenerator
	{
        public string GenerateLongName(string argName)
        {
            return SlugifyName(argName);
        }

        public string GenerateShortName(string longName)
        {
            return ShortifyName(longName);
        }

        internal string SlugifyName(string name)
        {
            if(string.IsNullOrWhiteSpace(name))
                throw new ArgumentNullException($"{nameof(name)} is empty or null");

            var s = Regex.Replace(name, @"[A-Z]", m => "-" + m.ToString().ToLower()).Replace(" ", string.Empty);
            while(s.Contains("--"))
                s = s.Replace("--", "-");
            while(s.StartsWith("-") || s.EndsWith("-") || s.StartsWith(" ") || s.EndsWith(" "))
                s = s.Trim('-').Trim(' ');

            return s;
        }

        internal string ShortifyName(string longName)
        {
            if(string.IsNullOrWhiteSpace(longName))
                throw new ArgumentNullException($"{nameof(longName)} is empty or null");
            
            var s = string.Join(string.Empty, longName.Split('-').Select(e=> e.First()).Take(2));
            return s;
        }
    }
}


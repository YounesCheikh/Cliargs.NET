using System;
using System.Collections.Generic;
using System.Linq;

namespace Cliargs
{
	class CliArgsContainer: ICliArgsContainer
	{
        private readonly Dictionary<string, CliArg> _cliArgs = new Dictionary<string, CliArg>();
        
        public IArgNamesGenerator ArgNamesGenerator { get; set; }

        /// <summary>
        /// The arguments dictionary
        /// </summary>
        public IReadOnlyDictionary<string, CliArg> CliArgs => _cliArgs;

        /// <summary>
        /// Create new instance of arguments container
        /// </summary>
        /// <returns>The created instnace</returns>
        internal CliArgsContainer() : this(CliArgsFormat.Default)
        {
            ArgumentsProvider = new ArgumentsProvider();
        }

        /// <summary>
        /// Create new instance of arugments container
        /// </summary>
        /// <param name="format">the created instance</param>
        internal CliArgsContainer(CliArgsFormat format)
		{
            if (format == null)
                throw new ArgumentNullException(nameof(format));

            this.Format = format;
            ArgumentsProvider = new ArgumentsProvider();
            this.ArgNamesGenerator = new ArgNamesGenerator();
		}

        public CliArgsFormat Format { get; private set; }

        /// <summary>
        /// The arguments provider
        /// </summary>
        /// <value>The arguments provider</value>
        public IArgumentsProvider ArgumentsProvider { get; set; }

        /// <summary>
        /// Get a typed argument value 
        /// </summary>
        /// <param name="argName">The argument name</param>
        /// <typeparam name="T">The argument value type</typeparam>
        /// <returns>The value</returns>
        public T? GetValue<T>(string argName)
        {
            if (!CliArgs.ContainsKey(argName))
                throw new CLIArgumentNotFoundException(argName);

            CliArg<T>? arg = CliArgs[argName] as CliArg<T>;

            if (arg != null)
                return arg.Value;

            throw new CliArgsException($"Invalid argument type for argument ({argName}, expected ({CliArgs[argName].GetType()}), but casting to {typeof(T)}");
        }

        /// <summary>
        /// Register a new argument to the container
        /// </summary>
        /// <param name="arg">The argument</param>
        /// <exception cref="CliArgsExecption">
        /// If another argument already registered with the same name, or long name or short name.
        /// </exception>
        public void Register(CliArg arg)
        {
            if(CliArgsOptions.Container.AutoGenerateNames) {
                if(string.IsNullOrWhiteSpace(arg.Info.LongName)) 
                {
                    var longName = this.ArgNamesGenerator.GenerateLongName(arg.Name);
                    if(this.CliArgs.All(e=> e.Value.Info.LongName != longName))
                        arg.Info.LongName = longName;
                }

                if(string.IsNullOrWhiteSpace(arg.Info.ShortName) && !string.IsNullOrWhiteSpace(arg.Info.LongName)){
                    var shortName = this.ArgNamesGenerator.GenerateShortName(arg.Info.LongName);
                    if(this.CliArgs.All(e=> e.Value.Info.ShortName != shortName))
                        arg.Info.ShortName = shortName;
                }
            }
            
            AddCliArg(arg);
        }

        /// <summary>
        /// Add a new argument
        /// </summary>
        /// <param name="arg">The argument to add</param>
        private void AddCliArg(CliArg arg)
        {
            if(this._cliArgs.Any(e=> e.Value.Info.Name == arg.Info.Name))
                throw new CliArgsException($"Another argument has the same name '{arg.Info.Name}'");

            if(!string.IsNullOrWhiteSpace(arg.Info.ShortName) 
            && this._cliArgs.Any(e=> e.Value.Info.ShortName == arg.Info.ShortName))
                throw new CliArgsException($"Another argument has the same short name '{arg.Info.ShortName}'");

            if(!string.IsNullOrWhiteSpace(arg.Info.LongName) 
            && this._cliArgs.Any(e=> e.Value.Info.LongName == arg.Info.LongName))
                throw new CliArgsException($"Another argument has the same long name '{arg.Info.LongName}'");
            
            this._cliArgs.Add(arg.Name, arg);
        }

        /// <summary>
        /// Get the argument value as an object
        /// </summary>
        /// <param name="argName">The argument name</param>
        /// <returns>The value object</returns>
        public object? GetValue(string argName)
        {
            if(!_cliArgs.TryGetValue(argName, out CliArg? arg))
                throw new CLIArgumentNotFoundException(argName);
            
            return arg.GetValue();
        }
    }
}


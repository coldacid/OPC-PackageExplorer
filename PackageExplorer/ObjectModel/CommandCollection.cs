using System;
using System.Collections.Generic;
using PackageExplorer.Core.AddInModel.Codons;

namespace PackageExplorer.ObjectModel
{
    public class CommandCollection
    {
        Dictionary<string, ICommand> _commands = null;

        public ICommand this[string name]
        {
            get
            {
                ICommand command;
                _commands.TryGetValue(name, out command);
                return command;
            }
        }

        public CommandCollection()
        {
            _commands = new Dictionary<string, ICommand>();
        }

        internal void Add(string commandName, ICommand command)
        {
            _commands.Add(commandName, command);
        }
    }
}

using System;
using PackageExplorer.Core.AddInModel.Codons;

namespace PackageExplorer.Commands
{
    public abstract class CommandBase
        : ICommand
    {
        string _name;
        
        public string Name
        {
            get { return _name; }
        }

        public CommandBase(string commandName)
        {
            _name = commandName;
        }

        public abstract void Execute();
    }
}

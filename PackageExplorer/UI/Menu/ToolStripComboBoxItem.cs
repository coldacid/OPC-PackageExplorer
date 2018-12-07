using System;
using PackageExplorer.Core.AddInModel.Codons;
using PackageExplorer.ObjectModel;

namespace PackageExplorer.UI.Menu
{
    public class ToolStripComboBoxItem
    {
        ICommand _command = null;

        public ICommand Command
        {
            get
            {
                if (_command == null)
                {
                    if (String.IsNullOrEmpty(CommandName) == false)
                    {
                        _command = Application.Commands[CommandName];
                    }
                }
                return _command;
            }
            set
            {
                _command = value;
            }
        }

        public string Title { get; set; }
        public string CommandName { get; set; }
    }
}

using System;
using PackageExplorer.UI.Menu;
using System.Collections;

namespace PackageExplorer.UI.Menu
{
    class CheckableToolStripMenuItem
        : ToolStripMenuItem
    {
        internal CheckableToolStripMenuItem(ToolStripMenuItemCodon codon, 
            object caller, ArrayList subItems)
            : base(codon, caller, subItems)
        {
        }

        public CheckableToolStripMenuItem(string title, 
            ICheckableMenuCommand command)
            : base(title, command)
        {
        }

        protected override void UpdateMenuItem()
        {
            ICheckableMenuCommand command = MenuCommand as ICheckableMenuCommand;
            if (command != null)
            {
                Checked = command.IsChecked;
            }
            base.UpdateMenuItem();
        }
    }
}

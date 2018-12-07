using System;
using PackageExplorer.Core.AddInModel.Codons;
using System.Collections;

namespace PackageExplorer.UI.Menu
{
    [CodonName("ToolStripSeparator")]
    class ToolStripSeparatorCodon
        : CodonBase
    {
        public override bool HandlesConditions
        {
            get { return true; }
        }

        public override object BuildItem(object owner,
            ArrayList subItems)
        {
            ToolStripSeparator separator = new ToolStripSeparator(this, owner);
            return separator;
        }
    }
}
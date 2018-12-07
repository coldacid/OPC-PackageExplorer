using System;
using PackageExplorer.Core.AddInModel.Codons;
using System.Collections;

namespace PackageExplorer.UI.Menu
{
    [CodonName("ToolStrip")]
    public class ToolStripCodon
        : CodonBase
    {
        public override object BuildItem(object owner, 
            ArrayList subItems)
        {
            ToolStrip strip = new ToolStrip(this, owner);
            foreach (System.Windows.Forms.ToolStripItem item in subItems)
            {
                strip.Items.Add(item);
            }
            return strip;
        }
    }
}

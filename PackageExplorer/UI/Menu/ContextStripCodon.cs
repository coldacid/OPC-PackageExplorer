using System;
using System.Collections;
using System.Windows.Forms;
using PackageExplorer.Core.AddInModel.Codons;

namespace PackageExplorer.UI.Menu
{
    [CodonName("ContextStrip")]
    public class ContextStripCodon
        : CodonBase
    {
        public override object BuildItem(object owner,
            ArrayList subItems)
        {
            ContextMenuStrip strip = new ContextMenuStrip();
            foreach (object item in subItems)
            {
                if (item is ToolStripItem)
                {
                    strip.Items.Add((ToolStripItem)item);
                }
            }
            return strip;
        }
    }
}

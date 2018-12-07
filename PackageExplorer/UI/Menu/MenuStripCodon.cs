using System;
using System.Collections;
using PackageExplorer.Core.AddInModel.Codons;
using System.Windows.Forms;

namespace PackageExplorer.UI.Menu
{
    [CodonName("MenuStrip")]
    public class MenuStripCodon
        : CodonBase
    {
        public override object BuildItem(object owner,
            ArrayList subItems)
        {
            MenuStrip strip = new MenuStrip(this, owner);
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

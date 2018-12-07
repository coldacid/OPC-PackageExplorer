using System;
using System.Collections;
using System.Windows.Forms;
using PackageExplorer.Core.AddInModel.Codons;

namespace PackageExplorer.UI.Menu
{
    [CodonName("ComboBoxBuilder")]
    class ComboBoxBuilderCodon
        : ClassCodon
    {
        public override bool HandlesConditions
        {
            get { return true; }
        }

        public override object BuildItem(object owner, 
            ArrayList subItems)
        {
            return (IComboBoxBuilder)base.BuildItem(owner, subItems);
        }
    }
}

using System;
using System.Collections;
using System.Windows.Forms;
using PackageExplorer.Core.AddInModel.Codons;

namespace PackageExplorer.UI.Menu
{
    [CodonName("MenuBuilder")]
    class MenuBuilderCodon
        : ClassCodon
    {
        public override bool HandlesConditions
        {
            get { return true; }
        }

        public override object BuildItem(object owner, 
            ArrayList subItems)
        {
            ISubMenuBuilder builder = (ISubMenuBuilder)base.BuildItem(owner, subItems);
            return builder;
        }
    }
}

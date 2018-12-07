using System;
using System.Collections;
using PackageExplorer.Core.AddInModel;
using PackageExplorer.Core.AddInModel.Codons;

namespace PackageExplorer.UI.Menu
{
    [CodonName("ToolStripLabel")]
    [RequiredAttribute("text")]
    class ToolStripLabelCodon
        : CodonBase
    {
        private string _text;

        public string Text
        {
            get { return _text; }
            set { _text = value; }
        }

        public override bool HandlesConditions
        {
            get { return true; }
        }

        public override object BuildItem(object owner, ArrayList subItems)
        {
            ToolStripLabel label = new ToolStripLabel(this, owner);
            return label;
        }
    }
}

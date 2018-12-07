using System;
using PackageExplorer.Core.AddInModel.Codons;
using PackageExplorer.Core.AddInModel.Conditions;

namespace PackageExplorer.UI.Menu
{
    class ToolStripSeparator
        : System.Windows.Forms.ToolStripSeparator, 
        IStatusEventReceiver
    {
        ICodon _codon = null;
        object _caller = null;

        public ToolStripSeparator(ICodon codon, object caller)
        {
            _codon = codon;
            _caller = caller;
        }

        public void Update()
        {
            ConditionFailedAction action = _codon.GetConditionFailedAction(_caller);
            Visible = (action & ConditionFailedAction.Exclude) != ConditionFailedAction.Exclude;
        }
    }
}

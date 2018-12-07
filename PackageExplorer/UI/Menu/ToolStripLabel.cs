using System;
using PackageExplorer.Core.Services;
using PackageExplorer.Core.AddInModel.Codons;
using PackageExplorer.Core.AddInModel.Conditions;

namespace PackageExplorer.UI.Menu
{
    class ToolStripLabel
        : System.Windows.Forms.ToolStripLabel,
        IStatusEventReceiver
    {
        ToolStripLabelCodon _codon;
        object _caller;

        public ToolStripLabel(ToolStripLabelCodon codon,
            object caller)
        {
            _codon = codon;
            _caller = caller;
        }

        public void Update()
        {
            StringParserService sps = ServiceManager.GetService<StringParserService>();
            Text = sps.Parse(_codon.Text);
            ConditionFailedAction action = _codon.GetConditionFailedAction(_caller);
            Enabled = action != ConditionFailedAction.Disable;
            Visible = action != ConditionFailedAction.Exclude;
        }
    }
}

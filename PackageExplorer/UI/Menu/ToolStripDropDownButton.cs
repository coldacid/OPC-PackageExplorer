using System;
using System.Windows.Forms;
using PackageExplorer.Core.Services;
using PackageExplorer.Core.AddInModel.Codons;
using PackageExplorer.Core.AddInModel.Conditions;

namespace PackageExplorer.UI.Menu
{
    class ToolStripDropDownButton
        : System.Windows.Forms.ToolStripDropDownButton,
        IStatusEventReceiver
    {
        ToolStripDropDownCodon _codon;
        object _caller;

        public ToolStripDropDownButton(ToolStripDropDownCodon codon,
            object caller)
        {
            _codon = codon;
            _caller = caller;
            ((IStatusEventReceiver)this).Update();
        }

        void IStatusEventReceiver.Update()
        {
            StringParserService parser = ServiceManager.GetService<StringParserService>();
            Text = parser.Parse(_codon.Title);
            DisplayStyle = _codon.DisplayStyle;
            if (String.IsNullOrEmpty(_codon.IconResource) == false)
            {
                ResourceService rs = ServiceManager.GetService<ResourceService>();
                Image = rs.GetImage(_codon.IconResource);
            }
            ConditionFailedAction action = _codon.GetConditionFailedAction(_caller);
            Enabled = (action & ConditionFailedAction.Disable) != ConditionFailedAction.Disable;
            Visible= (action & ConditionFailedAction.Exclude) != ConditionFailedAction.Exclude;
            foreach (ToolStripItem item in DropDownItems)
            {
                IStatusEventReceiver receiver = item as IStatusEventReceiver;
                if (receiver != null)
                {
                    receiver.Update();
                }
            }
        }
    }
}

using System;
using System.Windows.Forms;
using PackageExplorer.Core.AddInModel.Codons;
using PackageExplorer.Core.AddInModel.Conditions;

namespace PackageExplorer.UI.Menu
{
    public class ToolStrip
        : System.Windows.Forms.ToolStrip, IStatusEventReceiver
    {
        ICodon _menuCodon = null;
        object _caller = null;

        public ToolStrip(ICodon menuCodon, object caller)
        {
            _menuCodon = menuCodon;
            _caller = caller;
        }

        void IStatusEventReceiver.Update()
        {
            ConditionFailedAction action =
                _menuCodon.GetConditionFailedAction(_caller);
            this.SuspendLayout();
            try
            {
                Enabled = action != ConditionFailedAction.Disable;
                Visible = action != ConditionFailedAction.Exclude;
                foreach (ToolStripItem item in Items)
                {
                    IStatusEventReceiver receiver = item as IStatusEventReceiver;
                    if (receiver != null)
                    {
                        receiver.Update();
                    }
                }
            }
            finally
            {
                this.ResumeLayout();
                this.PerformLayout();
            }
        }
    }
}

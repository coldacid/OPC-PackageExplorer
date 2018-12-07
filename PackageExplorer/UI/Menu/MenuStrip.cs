using System;
using PackageExplorer.Core.AddInModel.Codons;
using PackageExplorer.Core.AddInModel.Conditions;
using System.Windows.Forms;

namespace PackageExplorer.UI.Menu
{
    class MenuStrip
        : System.Windows.Forms.MenuStrip, IStatusEventReceiver
    {
        ICodon _menuCodon = null;
        object _caller = null;

        public MenuStrip(ICodon menuCodon, object caller)
        {
            _menuCodon = menuCodon;
            _caller = caller;
        }

        void IStatusEventReceiver.Update()
        {
            this.SuspendLayout();
            try
            {
                ConditionFailedAction action =
                    _menuCodon.GetConditionFailedAction(_caller);
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
                this.ResumeLayout(false);
                this.PerformLayout();
            }
        }
    }
}

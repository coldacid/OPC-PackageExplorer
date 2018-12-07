using System;
using System.Windows.Forms;

namespace PackageExplorer.UI.Dialogs
{
    public class DialogContent
        : UserControl
    {
        public virtual bool ValidOnLoad
        {
            get { return false; }
        }

        protected void SetError(string message)
        {
            ((DialogWindow)ParentForm).ShowMessage(message);
        }

        protected void PerformValidation()
        {
            ParentForm.ValidateChildren(
                ValidationConstraints.Enabled | ValidationConstraints.Visible);
        }
    }
}

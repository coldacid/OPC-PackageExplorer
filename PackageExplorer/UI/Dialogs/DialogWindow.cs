using System;
using System.Windows.Forms;
using PackageExplorer.UI.Dialogs;
using PackageExplorer.Core;
using System.Drawing;

namespace PackageExplorer.UI.Dialogs
{
    partial class DialogWindow
        : Form
    {
        TableLayoutPanel _dialogLayoutPanel;
        Button _okButton;
        Button _cancelButton;
        DialogContent _dialogContent;

        public DialogWindow()
        {
            InitializeComponent();
        }

        public DialogWindow(DialogContent dialogContent, DialogButtons buttons)
        {
            InitializeComponent();
            if ((buttons & DialogButtons.Ok) != DialogButtons.Ok)
            {
                _okButton.Visible = false;
            }
            if ((buttons & DialogButtons.Cancel) != DialogButtons.Cancel)
            {
                _cancelButton.Visible = false;
            }
            dialogContent.Dock = DockStyle.Fill;
            _dialogLayoutPanel.Controls.Add(dialogContent, 0, 0);
            _dialogContent = dialogContent;
            SetStatus(_dialogContent.ValidOnLoad);
        }

        public override bool ValidateChildren(ValidationConstraints validationConstraints)
        {
            HideMessage();
            bool valid = base.ValidateChildren(validationConstraints);;
            _okButton.Enabled = valid;
            return valid;
        }

        internal void SetStatus(bool valid)
        {
            _okButton.Enabled = valid;
        }

        internal void ShowMessage(string message)
        {
            _errorLabel.Text = message;
            _errorPanel.Visible = true;
        }

        internal void HideMessage()
        {
            _errorPanel.Visible = false;
        }
    }
}

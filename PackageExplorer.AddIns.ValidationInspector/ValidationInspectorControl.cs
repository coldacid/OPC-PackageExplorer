using System;
using System.Windows.Forms;
using PackageExplorer.Core.Services;
using System.Drawing;
using PackageExplorer.UI;
using PackageExplorer.UI.Workbench;

namespace PackageExplorer.AddIns.ValidationInspector
{
    class ValidationInspectorControl
        : UserControl, IContentExplorer
    {
        public static readonly Guid ID = new Guid("{B3E58BDC-612D-40ec-84FF-085B66809D2C}");
        TextBox _validationErrorField = null;

        public Guid ExplorerID
        {
            get { return ID; }
        }

        public WindowKind WindowKind
        {
            get { return WindowKind.ToolWindow; }
        }

        public Control EditingControl
        {
            get { return this; }
        }

        public ValidationInspectorControl()
        {
            IValidationService service = (IValidationService)ServiceManager.Services[typeof(IValidationService)];
            service.ValidationMessage += ValidationService_ValidationMessage;
            _validationErrorField = new TextBox();
            _validationErrorField.ReadOnly = true;
            _validationErrorField.ScrollBars = ScrollBars.Vertical;

            _validationErrorField.BackColor = Color.White;
            _validationErrorField.Multiline = true;
            _validationErrorField.Dock = DockStyle.Fill;
            Controls.Add(_validationErrorField);
        }

        public void Clear()
        {
            _validationErrorField.Clear();
        }

        void ValidationService_ValidationMessage(object sender, ValidationEventArgs e)
        {          
            _validationErrorField.Text += e.Message + Environment.NewLine;
            Win32.ScrollToBottom(_validationErrorField.Handle);
        }
    }
}

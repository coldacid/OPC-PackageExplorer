using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using PackageExplorer.UI.Dialogs;
using PackageExplorer.Services;
using PackageExplorer.Core.Services;

namespace PackageExplorer.AddIns.ValidationInspector
{
    public partial class ValidationOptionsPanel 
        : PropertyPanel
    {
        ValidationSettings _settings = null;

        public ValidationOptionsPanel()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            ISettingsService service = ServiceManager.GetService<ISettingsService>();
            _settings = service.GetSettings<ValidationSettings>();
            _showInfoMessagesField.Checked = _settings.ShowInformationMessages;
            base.OnLoad(e);
        }

        public override bool ApplyChanges()
        {
            _settings.ShowInformationMessages = _showInfoMessagesField.Checked;
            return true;
        }

        void ShowInfoMessagesField_CheckedChanged(object sender, EventArgs e)
        {
            IsDirty = true;
        }
    }
}

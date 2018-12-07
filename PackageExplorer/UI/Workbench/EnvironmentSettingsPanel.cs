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

namespace PackageExplorer.UI.Workbench
{
    public partial class EnvironmentSettingsPanel 
        : PropertyPanel
    {
        EnvironmentSettings _environmentSettings = null;
        RecentDocumentSettings _recentDocumentSettings = null;
        
        public EnvironmentSettingsPanel()
        {
            InitializeComponent();
        }

        public override bool ApplyChanges()
        {
            _environmentSettings.ShowPackagingErrorsOnDocumentOpen = _showPackagingErrorsField.Checked;
            _environmentSettings.ShowStartPageOnApplicationStart = _showStartpageField.Checked;
            _recentDocumentSettings.MaxNrRecentDocuments = (int)_numberOfRecentDocumentsField.Value;
            return true;
        }

        protected override void OnLoad(EventArgs e)
        {
            ISettingsService service = ServiceManager.GetService<ISettingsService>();
            _environmentSettings = service.GetSettings<EnvironmentSettings>();
            _recentDocumentSettings = service.GetSettings<RecentDocumentSettings>();
            _numberOfRecentDocumentsField.Value = _recentDocumentSettings.MaxNrRecentDocuments;
            _showPackagingErrorsField.Checked = _environmentSettings.ShowPackagingErrorsOnDocumentOpen;
            _showStartpageField.Checked = _environmentSettings.ShowStartPageOnApplicationStart;
            base.OnLoad(e);
        }

        void ShowPackagingErrorsField_CheckedChanged(object sender, EventArgs e)
        {
            IsDirty = _showPackagingErrorsField.Checked != _environmentSettings.ShowPackagingErrorsOnDocumentOpen;
        }

        void ClearMRUListButton_Click(object sender, EventArgs e)
        {
            IRecentDocumentService service = ServiceManager.GetService<IRecentDocumentService>();
            service.Clear();
            WorkbenchSingleton.DefaultWorkbench.Refresh();
        }

        void ShowStartpageField_CheckedChanged(object sender, EventArgs e)
        {
            IsDirty = true;
        }

        void NumberOfRecentDocumentsField_ValueChanged(object sender, EventArgs e)
        {
            IsDirty = true;
        }
    }
}

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

namespace PackageExplorer.AddIns.XmlEditor
{
    public partial class XmlEditorOptionsPanel 
        : PropertyPanel
    {
        XmlEditorSettings _settings;

        public XmlEditorOptionsPanel()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            ISettingsService settingsService = ServiceManager.GetService<ISettingsService>();
            _settings = settingsService.GetSettings<XmlEditorSettings>();
            _formatXmlField.Checked = _settings.FormatXmlOnOpen;
            base.OnLoad(e);
        }

        public override bool ApplyChanges()
        {
            _settings.FormatXmlOnOpen = _formatXmlField.Checked;
            return true;
        }

        void _formatXmlField_CheckedChanged(object sender, EventArgs e)
        {
            IsDirty = true;
        }
    }
}

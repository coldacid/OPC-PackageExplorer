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
    public partial class CustomSchemaSettingsPanel 
        : PropertyPanel
    {
        ValidationSettings _validationSettings = null;

        public CustomSchemaSettingsPanel()
        {
            InitializeComponent();
        }

        public override bool ApplyChanges()
        {
            if (_validationSettings.CustomSchemaPaths == null)
            {
                _validationSettings.CustomSchemaPaths = new System.Collections.Specialized.StringCollection();
            }
            _validationSettings.CustomSchemaPaths.Clear();
            foreach (string path in _customSchemasField.Items)
            {
                _validationSettings.CustomSchemaPaths.Add(path);
            }
            return true;
        }

        protected override void OnLoad(EventArgs e)
        {
            ISettingsService settingsService = ServiceManager.GetService<ISettingsService>();
            _validationSettings = settingsService.GetSettings<ValidationSettings>();
            if (_validationSettings.CustomSchemaPaths != null)
            {
                foreach (string path in _validationSettings.CustomSchemaPaths)
                {
                    _customSchemasField.Items.Add(path);
                }
            }
            base.OnLoad(e);
        }

        void AddButton_Click(object sender, EventArgs e)
        {
            AddNewItems();
        }
        
        void RemoveButton_Click(object sender, EventArgs e)
        {
            RemoveActiveItem();
        }

        void AddNewItems()
        {
            using (OpenFileDialog dialog = new OpenFileDialog())
            {
                dialog.Multiselect = true;
                dialog.Filter = "Xml-Schema files|*.xsd";
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    foreach (string path in dialog.FileNames)
                    {
                        _customSchemasField.Items.Add(path);
                    }
                    IsDirty = dialog.FileNames.Length != 0;
                }
            }
        }

        void RemoveActiveItem()
        {
            if (_customSchemasField.SelectedIndex != -1)
            {
                int selectedIndex = _customSchemasField.SelectedIndex;
                _customSchemasField.Items.RemoveAt(selectedIndex);
                if (_customSchemasField.Items.Count > 0)
                {
                    if (selectedIndex > _customSchemasField.Items.Count)
                    {
                        selectedIndex = _customSchemasField.Items.Count - 1;
                    }
                    _customSchemasField.SelectedIndex = selectedIndex;
                }
                IsDirty = true;
            }
        }
    }
}
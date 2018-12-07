using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PackageExplorer.UI.Dialogs;
using PackageExplorer.ObjectModel.Vocabulary;
using System.Net.Mime;
namespace PackageExplorer.AddIns.DocumentFactory.Dialogs
{
    public partial class ContentTypePickerDialog 
        : DialogContent
    {
        public string SelectedContentType
        {
            get
            {
                return _useCustomContentTypeField.Checked ?
                    _customContentTypeField.Text :
                    (string)_contentTypeField.SelectedItem;
            }
        }

        public override bool ValidOnLoad
        {
            get
            {
                return VocabularyPart.ContentTypes.Count() > 0;
            }
        }

        public VocabularyPart VocabularyPart { get; set; }

        public ContentTypePickerDialog()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            if (VocabularyPart.ContentTypes.Count() > 0)
            {
                SetSelectionMode(false);
                _contentTypeField.Items.AddRange(
                    VocabularyPart.ContentTypes.ToArray());
                _contentTypeField.SelectedItem = 
                    VocabularyPart.ContentTypes.First();
                _useCustomContentTypeField.CheckedChanged +=
                    UseCustomContentTypeField_CheckedChanged;
                _contentTypeField.SelectedIndexChanged +=
                    delegate(object sender, EventArgs args)
                    {
                        PerformValidation();
                    };
            }
            else
            {
                SetSelectionMode(true);
                _useCustomContentTypeField.Checked = true;
                _useCustomContentTypeField.Enabled = false;
            }
            _customContentTypeField.TextChanged +=
                delegate(object sender, EventArgs arga)
                {
                    PerformValidation();
                };
            base.OnLoad(e);
        }

        void UseCustomContentTypeField_CheckedChanged(
            object sender, EventArgs e)
        {
            SetSelectionMode(_useCustomContentTypeField.Checked);
        }

        void SetSelectionMode(bool useCustomContentType)
        {
            _contentTypeField.Enabled = !useCustomContentType;
            _customContentTypeField.Enabled = useCustomContentType;
            _contentTypeField.SelectedIndex = -1;
            _contentTypeField.Text = null;
            _customContentTypeField.Text = null;
        }

        private void ContentTypeField_Validating(object sender, CancelEventArgs e)
        {
            if(_contentTypeField.SelectedIndex == -1)
            {
                e.Cancel = true;
            }
        }

        void CustomContentTypeField_Validating(object sender, CancelEventArgs e)
        {
            if (String.IsNullOrEmpty(_customContentTypeField.Text))
            {
                e.Cancel = true;
            }
            else if (_customContentTypeField.Text.Trim() != _customContentTypeField.Text)
            {
                SetError("The content-type is invalid.");
                e.Cancel = true;
            }
            else
            {
                try
                {
                    new ContentType(_customContentTypeField.Text);
                }
                catch (FormatException)
                {
                    SetError("The content-type is invalid.");
                    e.Cancel = true;
                }
            }
        }
    }
}

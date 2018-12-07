using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Linq;

namespace PackageExplorer.UI.Dialogs
{
    public partial class EncodingPickerDialog
        : DialogContent
    {
        class EncodingPickerItem
        {
            public int CodePage { get; set; }
            public string DisplayName { get; set; }
        }

        public string FileName
        {
            get { return _filenameLabel.Text; }
            set { _filenameLabel.Text = value; }
        }

        public Encoding SelectedEncoding
        {
            get
            {
                Encoding encoding = null;
                int selectedCodePage = ((EncodingPickerItem)_encodingField.SelectedItem).CodePage;
                if (selectedCodePage != -1)
                {
                    encoding = Encoding.GetEncoding(selectedCodePage);
                }
                return encoding;
            }
        }

        public override bool ValidOnLoad
        {
            get { return true; }
        }

        public EncodingPickerDialog()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            _encodingField.Items.AddRange(
                new EncodingPickerItem[]
                {
                    new EncodingPickerItem()
                    { 
                        CodePage= -1, 
                        DisplayName="{Auto-Detect}"
                    }
                }.Concat(
                    Encoding.GetEncodings().Select(
                        encodingInfo => new EncodingPickerItem()
                        {
                            DisplayName = encodingInfo.DisplayName,
                            CodePage = encodingInfo.CodePage
                        }
                        )).ToArray());
            _encodingField.SelectedIndex = 0;
            base.OnLoad(e);
        }
    }
}

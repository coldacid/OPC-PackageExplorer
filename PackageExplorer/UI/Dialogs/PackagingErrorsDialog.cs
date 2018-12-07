using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using PackageExplorer.ObjectModel;
using PackageExplorer.Core;

namespace PackageExplorer.UI.Dialogs
{
    public partial class PackagingErrorsDialog 
        : DialogContent
    {
        public Document Document { get; set; }

        public override bool ValidOnLoad
        {
            get { return true; }
        }

        public PackagingErrorsDialog()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            _errorsLabel.Text = String.Format(_errorsLabel.Text, Document.Filename);
            foreach (PackagingError error in Document.PackagingErrors)
            {
                _errorsField.Items.Add(error.Message);
            }
            base.OnLoad(e);
        }
    }
}

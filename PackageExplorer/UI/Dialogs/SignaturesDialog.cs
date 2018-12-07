using System;
using System.Windows.Forms;
using PackageExplorer.Core;
using System.Security.Cryptography.Xml;
using System.IO.Packaging;
using System.Drawing;
using System.Linq;
using Application = PackageExplorer.ObjectModel.Application;
using PackageExplorer.ObjectModel;
namespace PackageExplorer.UI.Dialogs
{
    public partial class SignaturesDialog 
        : DialogContent
    {
        public Document Document { get; set; }

        public override bool ValidOnLoad
        {
            get { return true; }
        }

        public SignaturesDialog()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            _signaturesList.Items.AddRange(
                Document.SignatureManager.Signatures.Select(
                    s => new ListViewItem(
                        new string[]{
                            s.Signer.Subject, s.SignatureType })).ToArray());
            base.OnLoad(e);
        }
    }
}

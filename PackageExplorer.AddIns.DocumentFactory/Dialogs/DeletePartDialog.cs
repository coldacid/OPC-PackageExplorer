using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PackageExplorer.ObjectModel;
using PackageExplorer.UI.Dialogs;

namespace PackageExplorer.AddIns.DocumentFactory.Dialogs
{
    public partial class DeletePartDialog
        : DialogContent
    {
        public DocumentPart SelectedPart
        {
            get
            {
                return (DocumentPart)_partField.SelectedItem;
            }
        }

        public bool DeleteChildren
        {
            get { return _deleteChildrenField.Checked; }
        }

        public override bool ValidOnLoad
        {
            get
            {
                return _handler.InitialSelection != null;
            }
        }

        IDeleteHandler _handler;

        interface IDeleteHandler
        {
            DocumentPart InitialSelection { get; }
            IEnumerable<DocumentPart> GetParts();
        }

        class PartDeleteHandler
            : IDeleteHandler
        {
            public DocumentPart InitialSelection
            {
                get { return Part; }
            }

            public DocumentPart Part { get; set; }

            public IEnumerable<DocumentPart> GetParts()
            {
                return Part.Document.AllParts;
            }
        }

        class DocumentDeleteHandler
            : IDeleteHandler
        {
            public DocumentPart InitialSelection
            {
                get { return null; }
            }

            public Document Document { get; set; }

            public IEnumerable<DocumentPart> GetParts()
            {
                return Document.AllParts;
            }
        }

        public DeletePartDialog()
        {
            InitializeComponent();
        }

        public DeletePartDialog(Document document)
        {
            _handler = new DocumentDeleteHandler() { Document = document };
            InitializeComponent();
        }

        public DeletePartDialog(DocumentPart documentPart)
        {
            _handler = new PartDeleteHandler() { Part = documentPart };
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            _partField.Items.AddRange(
                _handler.GetParts().ToArray());
            _partField.SelectedItem = _handler.InitialSelection;
            _partField.SelectedIndexChanged += PartField_SelectedIndexChanged;
            base.OnLoad(e);
        }

        void PartField_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_partField.SelectedItem != null)
            {
                DocumentPart part = (DocumentPart)_partField.SelectedItem;
                _childPartField.Items.Clear();
                _childPartField.Items.AddRange(
                    part.ChildParts.Where(
                        cp => cp.ParentRelationshipsCount == 1)
                    .Select(
                        cp => new ListViewItem(
                            new string[]{
                                cp.Uri.ToString(),
                                cp.ContentType,
                                cp.VocabularyPart != null ? 
                                    cp.VocabularyPart.Name : String.Empty}) { Tag = cp })
                    .ToArray());
            }
            PerformValidation();
        }

        void PartField_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = _partField.SelectedIndex == -1;
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PackageExplorer.ObjectModel;
using PackageExplorer.ObjectModel.Vocabulary;
using PackageExplorer.UI.Dialogs;
using System.Xml;

namespace PackageExplorer.AddIns.DocumentFactory.Dialogs
{
    public partial class RelationshipPickerDialog : DialogContent
    {
        public interface IRelationshipPicker
        {
            bool AllowExternal { get; }
            IEnumerable<DocumentPart> GetAvailableChildParts();
            IEnumerable<VocabularyLink> GetAvailableExternalRelationships();

            bool IsRelationshipIDInUse(string p);

            void CreateInternalRelationship(DocumentPart target, string relationshipID);
            void CreateExternalRelationship(string target, string relationshipType, string relationshipID);
        }

        public class DocumentRelationshipPicker
            : IRelationshipPicker
        {
            public Document Document { get; set; }
            public bool AllowExternal
            {
                get { return false; }
            }
            public IEnumerable<DocumentPart> GetAvailableChildParts()
            {
                string[] currentVocabularyPartNames = 
                    Document.MainParts.Where(p=>p.VocabularyPart != null)
                    .Select(p=> p.VocabularyPart.Name).ToArray();
                string[] allowedVocabularyParts =
                    Document.Vocabulary.AllGlobalReferences.Where(
                    gr => gr.MinOccurs > 0 ||
                        currentVocabularyPartNames.Contains(gr.Name) == false)
                   .Select( 
                    gr=> gr.Name).ToArray();
                return Document.AllParts.Where(
                    ap => Document.MainParts.Contains(ap) == false)
                    .Where(
                        ap => ap.VocabularyPart != null)
                    .Where(
                        ap => allowedVocabularyParts.Contains(ap.VocabularyPart.Name));
            }

            public IEnumerable<VocabularyLink> GetAvailableExternalRelationships()
            {
                return null;
            }

            public bool IsRelationshipIDInUse(string relationshipID)
            {
                return Document.MainParts.HasRelationshipID(relationshipID);
            }

            public void CreateInternalRelationship(DocumentPart target, string relationshipID)
            {
                if (String.IsNullOrEmpty(relationshipID) == false)
                {
                    Document.MainParts.Add(target, target.VocabularyPart.SourceRelationship, relationshipID);
                }
                else
                {
                    Document.MainParts.Add(target, target.VocabularyPart.SourceRelationship);
                }
            }

            public void CreateExternalRelationship(string target, string relationshipType, string relationshipID)
            {
                if (String.IsNullOrEmpty(relationshipID) == false)
                {
                    Document.ExternalRelationships.Add(
                        new Uri(target, UriKind.RelativeOrAbsolute), relationshipType, relationshipID);
                }
                else
                {
                    Document.ExternalRelationships.Add(
                        new Uri(target, UriKind.RelativeOrAbsolute), relationshipType);
                }
            }
        }

        public class DocumentPartRelationshipPicker
            : IRelationshipPicker
        {
            public DocumentPart DocumentPart { get; set; }

            public bool AllowExternal
            {
                get { return true; }
            }

            public IEnumerable<DocumentPart> GetAvailableChildParts()
            {
                string[] currentVocabularyPartNames =
                    DocumentPart.ChildParts.Where(p => p.VocabularyPart != null)
                    .Select(p => p.VocabularyPart.Name).ToArray();
                string[] allowedVocabularyParts =
                    DocumentPart.VocabularyPart.References.Where(
                    gr => gr.MinOccurs > 0 ||
                        currentVocabularyPartNames.Contains(gr.Name) == false)
                   .Select(
                        gr => gr.Name).ToArray();
                return DocumentPart.Document.AllParts.Where(
                    ap => DocumentPart.ChildParts.Contains(ap) == false)
                    .Where(
                        ap => ap.VocabularyPart != null)
                    .Where(
                        ap => allowedVocabularyParts.Contains(ap.VocabularyPart.Name));
            }

            public IEnumerable<VocabularyLink> GetAvailableExternalRelationships()
            {
                return DocumentPart.Document.Vocabulary.AllLinks.Where(
                    l => DocumentPart.VocabularyPart.LinkReferences.Where(
                        gr => gr.Name == l.Name).Count() > 0);
            }

            public bool IsRelationshipIDInUse(string relationshipID)
            {
                return DocumentPart.ChildParts.HasRelationshipID(relationshipID);
            }

            public void CreateInternalRelationship(DocumentPart target, string relationshipID)
            {
                if (String.IsNullOrEmpty(relationshipID) == false)
                {
                    DocumentPart.ChildParts.Add(target, target.VocabularyPart.SourceRelationship, relationshipID);
                }
                else
                {
                    DocumentPart.ChildParts.Add(target, target.VocabularyPart.SourceRelationship);
                }
            }

            public void CreateExternalRelationship(string target, string relationshipType, string relationshipID)
            {
                if (String.IsNullOrEmpty(relationshipID) == false)
                {
                    DocumentPart.ExternalRelationships.Add(
                        new Uri(target, UriKind.RelativeOrAbsolute), relationshipType, relationshipID);
                }
                else
                {
                    DocumentPart.ExternalRelationships.Add(
                        new Uri(target, UriKind.RelativeOrAbsolute), relationshipType);
                }
            }
        }

        IRelationshipPicker _picker;

        public bool HasPartSelected
        {
            get { return _tabs.SelectedTab == _existingPartsTab; }
        }

        public string RelationshipID
        {
            get { return _relationshipIDField.Text; }
        }

        public DocumentPart SelectedPart
        {
            get { return (DocumentPart)_partsField.SelectedItems[0].Tag; }
        }

        public string TargetLocation
        {
            get { return _locationField.Text; }
        }

        public string RelationshipType
        {
            get { return _relationshipTypeField.Text; }
        }

        public RelationshipPickerDialog()
        {
            InitializeComponent();
        }

        public RelationshipPickerDialog(IRelationshipPicker picker)
        {
            InitializeComponent();
            _picker = picker;
        }

        protected override void OnLoad(EventArgs e)
        {
            _partsField.Items.AddRange(
                _picker.GetAvailableChildParts().Select(
                    p => new ListViewItem(
                        new string[]{
                            p.Uri.ToString(),
                            p.VocabularyPart.Owner.Name,
                            p.VocabularyPart.Name,
                            p.ContentType
                        }) { Tag = p }).ToArray());
            _externalContentTab.Enabled = _picker.AllowExternal;
            if (_picker.AllowExternal)
            {
                _relationshipTypeField.Items.AddRange(
                    _picker.GetAvailableExternalRelationships().ToArray());
            }
            base.OnLoad(e);
        }

        void SetRelationshipIDMode(bool autoGenerate)
        {
            _customRelationshipIDPanel.Visible = !autoGenerate;
            _relationshipIDField.Enabled = !autoGenerate;
        }

        void AutoGenerateIDField_CheckedChanged(object sender, EventArgs e)
        {
            SetRelationshipIDMode(_autoGenerateIDField.Checked);
            PerformValidation();
        }

        void PartsField_SelectedIndexChanged(object sender, EventArgs e)
        {
            PerformValidation();
        }

        void Tabs_SelectedIndexChanged(object sender, EventArgs e)
        {
            PerformValidation();
        }

        void RelationshipIDField_TextChanged(object sender, EventArgs e)
        {
            PerformValidation();
        }

        void PartsField_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = _partsField.SelectedItems.Count == 0;
        }

        void RelationshipIDField_Validating(object sender, CancelEventArgs e)
        {
            if (String.IsNullOrEmpty(_relationshipIDField.Text))
            {
                e.Cancel = true;
                return;
            }
            else if (_picker.IsRelationshipIDInUse(_relationshipIDField.Text))
            {
                SetError("Relationship is already in use");
                e.Cancel = true;
            }
            else
            {
                try
                {
                    XmlConvert.VerifyName(_relationshipIDField.Text);
                }
                catch (XmlException)
                {
                    SetError("The relationship ID is invalid");
                    e.Cancel = true;
                }
            }
        }

        void LocationField_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = String.IsNullOrEmpty(_locationField.Text);
        }

        void RelationshipTypeField_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = String.IsNullOrEmpty(_relationshipTypeField.Text);
        }

        void Tabs_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = _tabs.SelectedTab.Enabled == false;
        }
    }
}

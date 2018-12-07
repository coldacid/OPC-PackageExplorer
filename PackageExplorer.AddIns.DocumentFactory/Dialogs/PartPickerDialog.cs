using System;
using System.Windows.Forms;
using PackageExplorer.UI.Dialogs;
using PackageExplorer.ObjectModel;
using PackageExplorer.ObjectModel.Vocabulary;
using System.Linq;
using System.Collections.Generic;
using System.IO;
using WinApp = System.Windows.Forms.Application;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Text;
using System.Xml.Linq;
using System.ComponentModel;
using System.Xml;

namespace PackageExplorer.AddIns.DocumentFactory.Dialogs
{
    public partial class PartPickerDialog 
        : DialogContent
    {
        #region Inner classes 
        internal interface IPartPickerHandler
        {
            string DocumentVocabulary { get; }
            IEnumerable<PackageVocabulary> GetVocabularies();
            IEnumerable<VocabularyPart> GetParts(PackageVocabulary vocabulary);
            bool IsRelationshipIDInUse(string relationshipID);
            bool IsLocationInUse(string location);
        }

        internal class DocumentHandler
            : IPartPickerHandler
        {
            public Document Document { get; set; }

            public string DocumentVocabulary
            {
                get { return Document.Vocabulary.Name; }
            }

            public IEnumerable<PackageVocabulary> GetVocabularies()
            {
                return Document.Vocabulary.AllGlobalReferences.Select(
                    r => r.Owner).Distinct();
            }

            public IEnumerable<VocabularyPart> GetParts(PackageVocabulary vocabulary)
            {
                return from p in
                           from r in vocabulary.GlobalReferences
                           select (from p in vocabulary.Parts
                                   where p.Name == r.Name
                                   where r.MaxOccurs > 1 || Document.MainParts.HasRelationship(p.SourceRelationship) == false
                                   select p).FirstOrDefault()
                       where p != null
                       select p;
            }

            public bool IsRelationshipIDInUse(string relationshipID)
            {
                return Document.MainParts.HasRelationshipID(relationshipID);
            }

            public bool IsLocationInUse(string location)
            {
                return Document.AllParts.Where(
                    p => String.Equals(p.Uri.ToString(), location, StringComparison.OrdinalIgnoreCase)).Count() > 0;
            }
        }

        internal class DocumentPartHandler
            : IPartPickerHandler
        {
            public DocumentPart Part { get; set; }
            
            public string DocumentVocabulary
            {
                get { return Part.VocabularyPart.Owner.Name; }
            }

            public IEnumerable<PackageVocabulary> GetVocabularies()
            {
                VocabularyPart part = Part.VocabularyPart;
                return part.References.Select(
                        r => r.Vocabulary) // get names
                    .Distinct() // make unique name list
                    .Select(name => part.Owner.GetVocabulary(name)); // get vocabulary
            }

            public IEnumerable<VocabularyPart> GetParts(PackageVocabulary vocabulary)
            {
                return from p in
                           from r in Part.VocabularyPart.References
                           where r.Vocabulary == vocabulary.Name
                           select (from p in vocabulary.Parts
                                   where p.Name == r.Name
                                   where r.MaxOccurs > 1 || Part.ChildParts.HasRelationship(p.SourceRelationship) == false
                                   select p).FirstOrDefault()
                       where p != null
                       select p;
            }

            public bool IsRelationshipIDInUse(string relationshipID)
            {
                return Part.ChildParts.HasRelationshipID(relationshipID);
            }

            public bool IsLocationInUse(string location)
            {
                return Part.Document.AllParts.Where(
                    p => String.Equals(p.Uri.ToString(), location, StringComparison.OrdinalIgnoreCase)).Count() > 0;
            }
        }
        #endregion

        IPartPickerHandler _handler;

        public string PartLocation
        {
            get { return _locationField.Text; }
        }

        public VocabularyPart VocabularyPart
        {
            get { return (VocabularyPart)_partTypesField.SelectedItems[0].Tag; }
        }

        public string RelationshipID
        {
            get { return _autoGenerateIDField.Checked ? _relationshipIDField.Text : null; }
        }

        public PartPickerDialog()
        {
            InitializeComponent();
        }

        public PartPickerDialog(Document document)
        {
            InitializeComponent();
            _handler = new DocumentHandler() { Document = document };
        }

        public PartPickerDialog(DocumentPart documentPart)
        {
            InitializeComponent();
            _handler = new DocumentPartHandler() { Part = documentPart };
        }

        protected override void OnLoad(EventArgs e)
        {
            LoadImages();
            TreeNode rootNode = new TreeNode("All Vocabularies") { ImageKey = "Folder", SelectedImageKey="Folder" };
            _vocabulariesField.Nodes.Add(rootNode);
            IEnumerable<PackageVocabulary> availableVocabularies = _handler.GetVocabularies();
            rootNode.Nodes.AddRange(
                availableVocabularies.Select(
                    v => new TreeNode(v.Name){Tag = v, ImageKey=v.Name, SelectedImageKey=v.Name})
                .ToArray());
            _partTypesField.Groups.AddRange(
                availableVocabularies.Select(
                    v => new ListViewGroup(v.Name, v.Name))
                .ToArray());
            rootNode.ExpandAll();
            _vocabulariesField.SelectedNode = rootNode;
            AddVocabularyItemsRecursive(rootNode);
            _vocabulariesField.AfterSelect += VocabulariesField_AfterSelect;
            base.OnLoad(e);
        }
    
        void VocabulariesField_AfterSelect(object sender, TreeViewEventArgs e)
        {
            _partTypesField.Items.Clear();
            AddVocabularyItemsRecursive(e.Node);
        }

        void PartTypesField_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_partTypesField.SelectedItems.Count > 0)
            {
                VocabularyPart part = (VocabularyPart)_partTypesField.SelectedItems[0].Tag;
                _descriptionLabel.Text = part.Description;
                UpdateLocationField(part);
            }
            else
            {
                _descriptionLabel.Text = null;
            }
            PerformValidation();
        }

        void AutoGenerateIDField_CheckedChanged(object sender, EventArgs e)
        {
            SetRelationshipIDMode(_autoGenerateIDField.Checked);
            PerformValidation();
        }

        void LocationField_TextChanged(object sender, EventArgs e)
        {
            PerformValidation();
        }

        void RelationshipIDField_TextChanged(object sender, EventArgs e)
        {
            PerformValidation();
        }

        void LoadImages()
        {
            string iconFolder = Path.Combine(
                WinApp.StartupPath, @"AddIns\Icons");
            if (Directory.Exists(iconFolder))
            {
                foreach (string iconFile in Directory.GetFiles(iconFolder, "*.ico"))
                {
                    string key = Path.GetFileNameWithoutExtension(iconFile);
                    _vocabularyImages.Images.Add(
                        key, new Icon(iconFile));
                    _largeImages.Images.Add(
                        key, new Icon(iconFile));
                }
            }
        }

        void UpdateLocationField(VocabularyPart part)
        {
            _locationField.Text = DefaultPartUri.GetDefaultUri(_handler.DocumentVocabulary, part);
        }

        void AddVocabularyItemsRecursive(TreeNode treeNode)
        {
            if (treeNode.Tag != null)
            {
                PackageVocabulary vocabulary = (PackageVocabulary)treeNode.Tag;
                _partTypesField.Items.AddRange(
                    _handler.GetParts(vocabulary).Select(
                     p => 
                     {
                        string key = String.Format("{0}_{1}", vocabulary.Name, p.Name);
                        return new ListViewItem(BuildPartTitle(p), _partTypesField.Groups[p.Owner.Name])
                        {
                            Tag = p,
                            ImageKey = _largeImages.Images.ContainsKey(key) ? key : "Generic_Xml",
                        };
                    })
                    .ToArray());
            }
            foreach (TreeNode node in treeNode.Nodes)
            {
                AddVocabularyItemsRecursive(node);
            }
        }

        string BuildPartTitle(VocabularyPart part)
        {
            MatchCollection matches = Regex.Matches(part.Name, @"[A-Z][^A-Z]*");
            StringBuilder resultBuilder = new StringBuilder();
            if (matches.Count > 0)
            {
                resultBuilder.Append(matches[0].Value);
                for (int i = 1; i < matches.Count; i++)
                {
                    resultBuilder.AppendFormat(" {0}", matches[i].Value);
                }
            }
            return resultBuilder.ToString();
        }
        
        void SetRelationshipIDMode(bool autoGenerate)
        {
            _customRelationshipIDPanel.Visible = !autoGenerate;
            _relationshipIDField.Enabled = !autoGenerate;
        }

        void PartTypesField_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = _partTypesField.SelectedItems.Count == 0;
        }

        void LocationField_Validating(object sender, CancelEventArgs e)
        {
            string location = _locationField.Text;
            if (String.IsNullOrEmpty(location))
            {
                e.Cancel = true;
            }
            else if (Uri.IsWellFormedUriString(location, UriKind.Relative) == false)
            {
                SetError("The location is not welformed");
                e.Cancel = true;
            }
            else if (location[0] != '/')
            {
                SetError("A part location should start with a '/' character");
                e.Cancel = true;
            }
            else if (String.IsNullOrEmpty(Path.GetFileName(location)))
            {
                e.Cancel = true;
            }
        }

        void RelationshipIDField_Validating(object sender, CancelEventArgs e)
        {
            if (String.IsNullOrEmpty(_relationshipIDField.Text))
            {
                e.Cancel = true;
                return;
            }
            else if (_handler.IsRelationshipIDInUse(_relationshipIDField.Text))
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
    }
}
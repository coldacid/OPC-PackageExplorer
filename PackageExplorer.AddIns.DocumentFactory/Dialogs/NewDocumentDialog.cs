using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PackageExplorer.Services;
using PackageExplorer.Core.Services;
using PackageExplorer.ObjectModel.Vocabulary;
using PackageExplorer.UI.Dialogs;
using System.IO;

namespace PackageExplorer.AddIns.DocumentFactory.Dialogs
{
    public partial class NewDocumentDialog 
        : DialogContent
    {
        public string SelectedContentType
        {
            get { return (string)_contentTypeField.SelectedItem; }
        }

        public PackageVocabulary SelectedVocabulary
        {
            get { return (PackageVocabulary)_vocabularyField.SelectedItems[0].Tag; }
        }

        public NewDocumentDialog()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            IVocabularyService vocabularyService = ServiceManager.GetService<IVocabularyService>();
            string imageFolder = Path.Combine(Application.StartupPath, @"AddIns\Icons");
            if (Directory.Exists(imageFolder))
            {
                foreach (string file in Directory.GetFiles(imageFolder))
                {
                    string key = Path.GetFileNameWithoutExtension(file);
                    _vocabularyIcons.Images.Add(key, new Icon(file));
                }
            }
            _vocabularyField.Items.AddRange(
                vocabularyService.Vocabularies.Where(
                    v => v.StartPart != null)
                .Select(
                    v => new ListViewItem(v.Name) { Tag = v, ImageKey = v.Name }).ToArray());
            base.OnLoad(e);
        }

        void VocabularyField_SelectedIndexChanged(object sender, EventArgs e)
        {
            _contentTypeField.Items.Clear();
            if (_vocabularyField.SelectedIndices.Count > 0)
            {
                PackageVocabulary vocabulary = (PackageVocabulary)_vocabularyField.SelectedItems[0].Tag;
                _contentTypeField.Items.AddRange(
                    vocabulary.Parts.Where(
                    p => p.Name == vocabulary.StartPart).First().ContentTypes.ToArray());
                _contentTypeField.SelectedIndex = 0;
            }
            PerformValidation();
        }

        private void _vocabularyField_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = _vocabularyField.SelectedIndices.Count == 0;
        }
    }
}

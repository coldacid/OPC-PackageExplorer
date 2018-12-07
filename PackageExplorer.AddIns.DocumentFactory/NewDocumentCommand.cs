using System;
using PackageExplorer.Commands;
using PackageExplorer.Services;
using PackageExplorer.Core.Services;
using PackageExplorer.AddIns.DocumentFactory.Dialogs;
using PackageExplorer.ObjectModel;
using PackageExplorer.ObjectModel.Vocabulary;
using System.Linq;
using PackageExplorer.UI.Dialogs;
using System.Windows.Forms;
using PackApp = PackageExplorer.ObjectModel.Application;

namespace PackageExplorer.AddIns.DocumentFactory
{
    class NewDocumentCommand
        : CommandBase
    {
        public NewDocumentCommand()
            : base("DocumentFactory.NewDocument")
        {
        }

        public override void Execute()
        {
            IDialogService dialogService = ServiceManager.GetService<IDialogService>();
            NewDocumentDialog dialog = new NewDocumentDialog();
            if (dialogService.ShowDialog(
                dialog, DialogButtons.Ok | DialogButtons.Cancel) == DialogResult.OK)
            {
                Document document = PackApp.Documents.New(
                    "document", dialog.SelectedVocabulary);
                VocabularyPart vpart = dialog.SelectedVocabulary.Parts.Where(
                    vp => vp.Name == dialog.SelectedVocabulary.StartPart).First();
                string uri = DefaultPartUri.GetDefaultUri(dialog.SelectedVocabulary.Name, vpart) ?? "/startpart.xml";
                DocumentPart dpart = document.CreatePart(uri, dialog.SelectedContentType);
                document.MainParts.Add(dpart, vpart.SourceRelationship);
            }
        }
    }
}

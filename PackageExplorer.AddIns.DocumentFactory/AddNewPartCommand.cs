using System;
using PackageExplorer.Commands;
using PackageExplorer.Services;
using PackageExplorer.Core.Services;
using PackageExplorer.UI.Workbench;
using PackageExplorer.AddIns.DocumentInspector;
using PackageExplorer.ObjectModel.Vocabulary;
using PackageExplorer.ObjectModel;
using System.Linq;
using PackageExplorer.AddIns.DocumentFactory.Dialogs;
using System.Windows.Forms;
using PackageExplorer.UI.Dialogs;
namespace PackageExplorer.AddIns.DocumentFactory
{
    class AddNewPartCommand
        : CommandBase
    {
        public AddNewPartCommand()
            : base("DocumentFactory.AddNewPart")
        {
        }

        public override void Execute()
        {
            WorkbenchService workbenchService = ServiceManager.GetService<WorkbenchService>();
            IWindow window = workbenchService.GetWindow(DocumentInspectorControl.ID);
            DocumentInspectorControl control = (DocumentInspectorControl)window.WindowControl;

            IDialogService dialogService = ServiceManager.GetService<IDialogService>();
            if (control.SelectedNode is DocumentNode)
            {
                Document document = ((DocumentNode)control.SelectedNode).Document;
                PartPickerDialog dialog = new PartPickerDialog(document);
                if (dialogService.ShowDialog(dialog, DialogButtons.Ok | DialogButtons.Cancel) == DialogResult.OK)
                {
                    DocumentPart dpart = CreatePart(document,
                        dialog.PartLocation,
                        dialog.VocabularyPart, dialogService);
                    if (dpart != null)
                    {
                        if (dialog.RelationshipID == null)
                        {
                            document.MainParts.Add(dpart, dialog.VocabularyPart.SourceRelationship);
                        }
                        else
                        {
                            document.MainParts.Add(dpart, dialog.VocabularyPart.SourceRelationship, dialog.RelationshipID);
                        }
                    }
                }
            }
            else if (control.SelectedNode is DocumentPartNode)
            {
                DocumentPart part = ((DocumentPartNode)control.SelectedNode).DocumentPart;
                Document document = part.Document;
                PartPickerDialog dialog = new PartPickerDialog(part);
                if (dialogService.ShowDialog(dialog, DialogButtons.Ok | DialogButtons.Cancel) == DialogResult.OK)
                {
                    DocumentPart dpart = CreatePart(
                        document, dialog.PartLocation, dialog.VocabularyPart, dialogService);
                    if (dpart != null)
                    {
                        if (dialog.RelationshipID == null)
                        {
                            part.ChildParts.Add(dpart, dialog.VocabularyPart.SourceRelationship);
                        }
                        else
                        {
                            part.ChildParts.Add(dpart, 
                                dialog.VocabularyPart.SourceRelationship, 
                                dialog.RelationshipID);
                        }
                    }
                }
            }
        }

        DocumentPart CreatePart(Document document, string location, 
            VocabularyPart vpart, IDialogService dialogService)
        {
            string contentType = null;
            if (vpart.ContentTypes.Count() == 0 ||
                vpart.ContentTypes.Count() > 1)
            {
                ContentTypePickerDialog dialog = new ContentTypePickerDialog();
                dialog.VocabularyPart = vpart;
                if (dialogService.ShowDialog(dialog, DialogButtons.Ok | DialogButtons.Cancel) == DialogResult.Cancel)
                {
                    return null;
                }
                contentType = dialog.SelectedContentType;
            }
            else
            {
                contentType = vpart.ContentTypes.First();
            }
            DocumentPart part = document.CreatePart(location, contentType);
            return part;
        }
    }
}
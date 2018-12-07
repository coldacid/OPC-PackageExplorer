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
    class AddRelationshipCommand
        : CommandBase
    {
        public AddRelationshipCommand()
            : base("DocumentFactory.AddRelationship")
        {
        }

        public override void Execute()
        {
            WorkbenchService workbenchService = ServiceManager.GetService<WorkbenchService>();
            IWindow window = workbenchService.GetWindow(DocumentInspectorControl.ID);
            DocumentInspectorControl control = (DocumentInspectorControl)window.WindowControl;

            IDialogService dialogService = ServiceManager.GetService<IDialogService>();
            RelationshipPickerDialog dialog = null;
            RelationshipPickerDialog.IRelationshipPicker picker = null;
            if (control.SelectedNode is DocumentNode)
            {
                picker = new RelationshipPickerDialog.DocumentRelationshipPicker() { Document = ((DocumentNode)control.SelectedNode).Document };
            }
            else
            {
                picker = new RelationshipPickerDialog.DocumentPartRelationshipPicker() { DocumentPart = ((DocumentPartNode)control.SelectedNode).DocumentPart };
            }
            dialog = new RelationshipPickerDialog(picker);
            if (dialogService.ShowDialog(dialog, DialogButtons.Ok | DialogButtons.Cancel) == DialogResult.OK)
            {
                if (dialog.HasPartSelected)
                {
                    DocumentPart target = dialog.SelectedPart;
                    picker.CreateInternalRelationship(target, dialog.RelationshipID);
                }
                else
                {
                    picker.CreateExternalRelationship(dialog.TargetLocation, dialog.RelationshipType, dialog.RelationshipID);
                }
            }
        }
    }
}
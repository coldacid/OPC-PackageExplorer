using System;
using PackageExplorer.Commands;
using System.Windows.Forms;
using PackageExplorer.Services;
using PackageExplorer.UI.Workbench;
using PackageExplorer.AddIns.DocumentInspector;
using PackageExplorer.Core.Services;
using PackageExplorer.ObjectModel;
using PackageExplorer.AddIns.DocumentFactory.Dialogs;
using PackageExplorer.UI.Dialogs;

namespace PackageExplorer.AddIns.DocumentFactory
{
    class DeletePartCommand
        : CommandBase
    {
        public DeletePartCommand()
            : base("DocumentFactory.DeletePart")
        {
        }

        public override void Execute()
        {
            WorkbenchService workbenchService = ServiceManager.GetService<WorkbenchService>();
            IDialogService dialogService = ServiceManager.GetService<IDialogService>();
            
            IWindow window = workbenchService.GetWindow(DocumentInspectorControl.ID);
            DocumentInspectorControl control = (DocumentInspectorControl)window.WindowControl;
            DeletePartDialog dialog = null;
            if (control.SelectedNode is DocumentPartNode)
            {
                DocumentPartNode node = (DocumentPartNode)control.SelectedNode;
                DocumentPart part = node.DocumentPart;
                dialog = new DeletePartDialog(part);
            }
            else
            {
                DocumentNode node = (DocumentNode)control.SelectedNode;
                Document document = node.Document;
                dialog = new DeletePartDialog(document);
            }
            if (dialogService.ShowDialog(
                dialog, DialogButtons.Ok | DialogButtons.Cancel) == DialogResult.OK)
            {
                DocumentPart part = dialog.SelectedPart;
                bool deleteChildren = dialog.DeleteChildren;
                try
                {
                    control.BeginUpdate();
                    part.Document.DeletePart(part, deleteChildren);
                }
                finally
                {
                    control.EndUpdate();
                }
            }
        }
    }
}

using System;
using PackageExplorer.Commands;
using PackageExplorer.Services;
using PackageExplorer.UI.Workbench;
using PackageExplorer.AddIns.DocumentInspector;
using PackageExplorer.AddIns.DocumentFactory.Dialogs;
using PackageExplorer.Core.Services;
using PackageExplorer.ObjectModel;
using System.Windows.Forms;

namespace PackageExplorer.AddIns.DocumentFactory
{
    class RemoveFromParentCommand
        : CommandBase
    {
        public RemoveFromParentCommand()
            : base("DocumentFactory.RemoveFromParent")
        {
        }

        public override void Execute()
        {
            WorkbenchService workbenchService = ServiceManager.GetService<WorkbenchService>();
            
            IWindow window = workbenchService.GetWindow(DocumentInspectorControl.ID);
            DocumentInspectorControl control = (DocumentInspectorControl)window.WindowControl;
            DocumentPartNode node = (DocumentPartNode)control.SelectedNode;
            DocumentPartCollection parts = null;
            DocumentPart part = node.DocumentPart;
            if (node.Parent is DocumentNode)
            {
                parts = ((DocumentNode)node.Parent).Document.MainParts;
            }
            else
            {
                parts = ((DocumentPartNode)node.Parent).DocumentPart.ChildParts;
            }
            bool deleteAfterRemove = false;
            if (part.ParentRelationshipsCount == 1)
            {
                deleteAfterRemove =
                    MessageBox.Show("You are removing the last relationship to this part. Do you wish to delete the part?",
                    System.Windows.Forms.Application.ProductName, MessageBoxButtons.YesNo) == DialogResult.Yes;
            }
            if (deleteAfterRemove)
            {
                part.Document.DeletePart(part, false);
            }
            else
            {
                parts.Remove(part);
            }
        }
    }
}

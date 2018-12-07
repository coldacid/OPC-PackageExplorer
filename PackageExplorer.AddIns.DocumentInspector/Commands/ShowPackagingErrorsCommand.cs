using System;
using System.Collections.Generic;
using System.Text;
using PackageExplorer.Services;
using PackageExplorer.Core.Services;
using PackageExplorer.UI.Workbench;
using PackageExplorer.ObjectModel;
using PackageExplorer.Commands;
using PackageExplorer.UI.Dialogs;

namespace PackageExplorer.AddIns.DocumentInspector.Commands
{
    class ShowPackagingErrorsCommand
        : CommandBase
    {
        public ShowPackagingErrorsCommand()
            : base("DocumentInspector.ShowPackagingErrors")
        {
        }

        public override void Execute()
        {
            WorkbenchService workbenchService = 
                ServiceManager.GetService<WorkbenchService>();
            IWindow inspectorWindow = 
                workbenchService.GetWindow(DocumentInspectorControl.ID);
            DocumentInspectorControl inspectorControl = 
                (DocumentInspectorControl)inspectorWindow.WindowControl;
            DocumentNode documentNode = 
                inspectorControl.SelectedNode as DocumentNode;
            if (documentNode != null)
            {
                IDialogService dialogService = 
                    ServiceManager.GetService<IDialogService>();
                PackagingErrorsDialog dialog = new PackagingErrorsDialog()
                {
                    Document = documentNode.Document
                };
                dialogService.ShowDialog(dialog, DialogButtons.Ok);
            }
        }
    }
}

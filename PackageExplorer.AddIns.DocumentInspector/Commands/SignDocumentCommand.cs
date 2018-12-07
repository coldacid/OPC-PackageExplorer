using System;
using PackageExplorer.Core;
using System.Security.Cryptography.X509Certificates;
using PackageExplorer.Core.Services;
using PackageExplorer.ObjectModel;
using PackageExplorer.Commands;
using PackageExplorer.Services;
using PackageExplorer.UI.Workbench;

namespace PackageExplorer.AddIns.DocumentInspector.Commands
{
    class SignDocumentCommand
        : CommandBase
    {
        public SignDocumentCommand()
            : base("DocumentInspector.SignDocument")
        {

        }

        public override void Execute()
        {
            WorkbenchService workbenchService = ServiceManager.GetService<WorkbenchService>();
            IWindow window = workbenchService.GetWindow(DocumentInspectorControl.ID);
            DocumentInspectorControl control = (DocumentInspectorControl)window.WindowControl;
            DocumentNode documentNode = control.SelectedNode as DocumentNode;
            if (documentNode != null)
            {

                X509Store certStore = new X509Store(StoreLocation.CurrentUser);
                certStore.Open(OpenFlags.ReadOnly);
                X509Certificate2Collection certs =
                    X509Certificate2UI.SelectFromCollection(
                        certStore.Certificates,
                        "Select a certificate",
                        "Please select a certificate",
                        X509SelectionFlag.SingleSelection);
                if (certs.Count > 0)
                {
                    documentNode.Document.SignatureManager.Sign(certs[0]);
                }
            }
        }
    }
}

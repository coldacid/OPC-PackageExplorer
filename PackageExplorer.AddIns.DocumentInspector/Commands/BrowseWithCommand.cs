using System;
using PackageExplorer.Services;
using PackageExplorer.Core.Services;
using PackageExplorer.UI.Workbench;
using PackageExplorer.Commands;
using PackageExplorer.ObjectModel;
using System.Text;
using PackageExplorer.UI.Dialogs;
using System.Windows.Forms;

namespace PackageExplorer.AddIns.DocumentInspector.Commands
{
    class BrowseWithCommand
        : CommandBase
    {
        public BrowseWithCommand()
            : base("DocumentInspector.BrowseWith")
        {
        }


        public override void Execute()
        {
            WorkbenchService workbenchService = ServiceManager.GetService<WorkbenchService>();
            IWindow window = workbenchService.GetWindow(DocumentInspectorControl.ID);
            DocumentInspectorControl control = (DocumentInspectorControl)window.WindowControl;
            DocumentPartNode partNode = control.SelectedNode as DocumentPartNode;
            if (partNode != null)
            {
                IDialogService dialogService = ServiceManager.GetService<IDialogService>();
                BrowseWithDialog browseDialog = new BrowseWithDialog() { DocumentPart = partNode.DocumentPart };
                if (dialogService.ShowDialog(browseDialog,
                    DialogButtons.Ok | DialogButtons.Cancel) == DialogResult.OK)
                {
                    EditorInfo editorInfo = browseDialog.SelectedItem;
                    DocumentPart part = partNode.DocumentPart;
                    WorkbenchService ws = ServiceManager.GetService<WorkbenchService>();
                    IEditorService es = ServiceManager.GetService<IEditorService>();
                    Encoding encoding = null;
                    if (editorInfo.SupportsEncoding)
                    {
                        EncodingPickerDialog encodingDialog = new EncodingPickerDialog()
                        {
                            FileName = part.Uri.ToString()
                        };
                        if (dialogService.ShowDialog(encodingDialog, DialogButtons.Ok | DialogButtons.Cancel) == DialogResult.OK)
                        {
                            encoding = encodingDialog.SelectedEncoding;
                        }
                        else
                        {
                            return;
                        }
                    }
                    IWindow partWindow = ws.Open(part, false, 
                        es.CreateEditor(editorInfo), encoding);
                    partWindow.Show();
                }
            }
        }
    }
}

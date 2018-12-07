using System;
using PackageExplorer.Core;
using ICSharpCode.TextEditor;
using System.Xml;
using System.Text;
using PackageExplorer.UI.Workbench;
using PackageExplorer.Core.AddInModel.Codons;
using System.Windows.Forms;
using System.ComponentModel.Design;
using PackageExplorer.Core.Services;

namespace PackageExplorer.AddIns.XmlEditor
{
    class FormatDocumentCommand
        : ICommand
    {
        public string Name
        {
            get { return "XmlEditor.FormatDocument"; }
        }

        public FormatDocumentCommand()
        {
        }

        public void Execute()
        {
            IWindow activeWindow = WorkbenchSingleton.DefaultWorkbench.ActiveDocumentWindow;
            if (activeWindow != null)
            {
                XmlEditorControl control = activeWindow.WindowControl as XmlEditorControl;
                if (control != null)
                {
                    control.Format();
                }
            }
        }
    }
}

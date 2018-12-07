using System;
using System.Windows.Forms;

namespace PackageExplorer.UI.Workbench
{
    public interface IWorkbench
    {        
        void Show();

        IWindow ActiveDocumentWindow { get;}

        IWindow CreateDocumentWindow(Control content, string title);
        IWindow CreateInspectorWindow(Control content, string title, Guid windowID, ToolStrip inspectorMenu);

        void Refresh();

        event EventHandler ActiveDocumentWindowChanged;
        event EventHandler ActiveWindowChanged;
    }
}

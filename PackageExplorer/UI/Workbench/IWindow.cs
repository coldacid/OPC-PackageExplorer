using System;
using System.Windows.Forms;
using System.ComponentModel;
using WeifenLuo.WinFormsUI.Docking;

namespace PackageExplorer.UI.Workbench
{
    public interface IWindow
    {
        Control WindowControl { get;}
        string Text { get; set;}
        void Show();
        void Hide();
        bool Close();

        event CancelEventHandler Closing;
        event EventHandler Closed;

        void Refresh();

        void Show(DockState dockState);
    }
}

using System;
using System.Windows.Forms;
using PackageExplorer.UI.Workbench;

namespace PackageExplorer.AddIns.BrowserEditor
{
    class BrowserEditorControl
        : WebBrowser
    {
        public BrowserEditorControl()
        {
            this.AllowNavigation = false;
            this.AllowWebBrowserDrop = false;
        }

        protected override void OnCreateControl()
        {

            base.OnCreateControl();
        }
    }
}

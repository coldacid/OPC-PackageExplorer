using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using PackageExplorer.UI.Workbench;
using System.IO;
using System.Reflection;
using PackageExplorer.Services;
using PackageExplorer.Core.Services;

namespace PackageExplorer.StartPage
{
    class ContentExplorer : IContentExplorer
    {
        WebBrowser _browser = null;

        public WindowKind WindowKind
        {
            get { return WindowKind.DocumentWindow; }
        }

        public Guid ExplorerID
        {
            get { return new Guid("{80F8D15B-29BD-4140-A574-D0AB12664126}"); }
        }

        public System.Windows.Forms.Control EditingControl
        {
            get { return _browser; }
        }

        public ContentExplorer()
        {
            _browser = new WebBrowser();
            _browser.ObjectForScripting = new ScriptProxy(_browser);            
            _browser.IsWebBrowserContextMenuEnabled = false;
            
            using (StreamReader reader = new StreamReader(
                Assembly.GetExecutingAssembly().GetManifestResourceStream(
                    "PackageExplorer.StartPage.StartPage.htm")))
            {
                _browser.DocumentText = reader.ReadToEnd();
            }
            
            _browser.Navigating += Browser_Navigating;    
        }

        void Browser_Navigating(object sender, WebBrowserNavigatingEventArgs e)
        {
            e.Cancel = true;
            if (e.Url != new Uri("about:blank", UriKind.RelativeOrAbsolute))
            {
                WorkbenchService ws = ServiceManager.GetService<WorkbenchService>();
                IWindow window = ws.Open(e.Url);
                if (window != null)
                {
                    window.Show();
                }
            }
        }
    }
}

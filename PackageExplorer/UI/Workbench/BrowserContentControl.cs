using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace PackageExplorer.UI.Workbench
{
    public partial class BrowserContentControl : UserControl
    {
        public Uri Uri
        {
            get { return _webBrowser.Url; }
            set
            {
                _webBrowser.Url = value;
            }
        }

        public BrowserContentControl()
        {
            InitializeComponent();
        }

        private void _webBrowser_Navigated(object sender, WebBrowserNavigatedEventArgs e)
        {
            _urlField.Text = e.Url.ToString();
        }

        private void _urlField_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                _webBrowser.Navigate(_urlField.Text);
            }
        }
    }
}

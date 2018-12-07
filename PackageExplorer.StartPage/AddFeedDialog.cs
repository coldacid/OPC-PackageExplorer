using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PackageExplorer.StartPage
{
    public partial class AddFeedDialog : Form
    {
        public string Url
        {
            get { return _rssFeedField.Text; }
        }

        public AddFeedDialog()
        {
            InitializeComponent();
        }
    }
}

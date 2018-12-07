using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Reflection;

namespace PackageExplorer.UI.Dialogs
{
    public partial class ErrorDialog : Form
    {
        const string _codePlexPage = "http://www.codeplex.com/PackageExplorer/WorkItem/Create.aspx";
        Exception _exception = null;

        public ErrorDialog(Exception exception)
        {
            _exception = exception;
            InitializeComponent();
            _errorMessageField.Text = exception.Message;
            StringBuilder errorBuilder = new StringBuilder();
            Exception e = exception;
            int tabIndex = 0;
            while (e != null)
            {
                string tab = new string(' ', tabIndex);
                errorBuilder.AppendLine(tab + e.Message);
                e = e.InnerException;
                tabIndex++;
            }
            errorBuilder.AppendLine();
            errorBuilder.AppendFormat("Runtime version: {0}" + Environment.NewLine,
                RuntimeEnvironment.GetSystemVersion());
            errorBuilder.AppendLine();
            errorBuilder.AppendLine("Loaded assemblies:");
            foreach (Assembly assembly in AppDomain.CurrentDomain.GetAssemblies())
            {
                errorBuilder.AppendLine(assembly.GetName().FullName);
            }
            errorBuilder.AppendLine();
            errorBuilder.AppendLine(exception.StackTrace);
            _detailsField.Text = errorBuilder.ToString();
            _detailsField.Visible = false;
        }

        void _viewDetailsButton_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            _detailsField.Visible = !_detailsField.Visible;
        }

        private void _reportErrorLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ProcessStartInfo info = new ProcessStartInfo(
                     _codePlexPage);
            Process.Start(info);
        }
    }
}
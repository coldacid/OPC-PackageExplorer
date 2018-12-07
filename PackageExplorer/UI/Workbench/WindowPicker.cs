using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PackageExplorer.Services;
using PackageExplorer.Core.Services;

namespace PackageExplorer.UI.Workbench
{
    public partial class WindowPicker : Form
    {
        List<IWindow> _windowActivationList;
        bool _manualSelect = false;

        protected override bool ShowWithoutActivation
        {
            get { return true; }
        } 

        public WindowPicker()
        {
            InitializeComponent();
            _windowActivationList = new List<IWindow>(25);
            WorkbenchService service = ServiceManager.GetService<WorkbenchService>();
            foreach (IWindow documentWindow in service.DocumentWindows)
            {
                AddWindow(documentWindow);
            }
            WorkbenchSingleton.DefaultWorkbench.ActiveDocumentWindowChanged +=
                delegate(object sender, EventArgs e)
                {
                    IWindow window = WorkbenchSingleton.DefaultWorkbench.ActiveDocumentWindow;
                    if (window != null)
                    {
                        AddWindow(WorkbenchSingleton.DefaultWorkbench.ActiveDocumentWindow);
                    }
                };
        }
        
        private void AddWindow(IWindow window)
        {
            if (_windowActivationList.Contains(window))
            {
                _windowActivationList.Remove(window);
            }
            _windowActivationList.Insert(0, window);
            window.Closed += DocumentWindow_Closed;
        }

        void DocumentWindow_Closed(object sender, EventArgs e)
        {
            RemoveWindow((IWindow)sender);
        }

        private void RemoveWindow(IWindow window)
        {
            window.Closed -= DocumentWindow_Closed;
            _windowActivationList.Remove(window);
        }

        internal void InitializeItems()
        {
            try
            {
                _manualSelect = true;
                _currentWindowLabel.Text = WorkbenchSingleton.DefaultWorkbench.ActiveDocumentWindow.Text;
                _windowsField.Items.Clear();
                _inspectorsField.Items.Clear();
                WorkbenchService service = ServiceManager.GetService<WorkbenchService>();
                _inspectorsField.Items.AddRange(service.InspectorWindows.ToArray());
                _windowsField.Items.AddRange(_windowActivationList.ToArray());
                if (_windowsField.Items.Count > 1)
                {
                    _windowsField.SelectedIndex = 1;
                }
                else
                {
                    _windowsField.SelectedIndex = 0;
                }
            }
            finally
            {
                _manualSelect = false;
            }
        }

        internal void SelectNext()
        {
            try
            {
                _manualSelect = true;
                if (_windowsField.SelectedIndex == _windowsField.Items.Count - 1)
                {
                    _windowsField.SelectedIndex = 0;
                }
                else
                {
                    _windowsField.SelectedIndex++;
                }
            }
            finally
            {
                _manualSelect = false;
            }
        }

        internal void ActivateSelectedDocumentWindow()
        {
            IWindow window = (IWindow)_windowsField.SelectedItem;
            if (window != WorkbenchSingleton.DefaultWorkbench.ActiveDocumentWindow)
            {
                window.Show();
            }
            Hide();                
        }

        private void WindowsField_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_manualSelect == false)
            {
                ActivateSelectedDocumentWindow();
            }
        }

        private void InspectorsField_SelectedIndexChanged(object sender, EventArgs e)
        {
            ((IWindow)_inspectorsField.SelectedItem).Show();
            Hide();
        }
    }
}

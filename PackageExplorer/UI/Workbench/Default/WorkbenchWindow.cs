using System;
using System.Windows.Forms;
using PackageExplorer.Core.AddInModel.Codons;
using WeifenLuo.WinFormsUI.Docking;

namespace PackageExplorer.UI.Workbench.Default
{
    class WorkbenchWindow
        : DockContent, IWindow
    {
        ToolStrip _windowToolStrip = null;
        DockPanel _dockPanel = null;
        Control _windowControl = null;
        Guid? _windowID = null;
        DockState _defaultDockState = DockState.Document;
        bool _closing = false;
        
        public DockState DefaultDockState
        {
            get { return _defaultDockState; }
            set { _defaultDockState = value; }
        }

        public Control WindowControl
        {
            get { return _windowControl; }
        }

        public WorkbenchWindow(DockPanel dockPanel, Control windowControl,
            string title, Guid? windowID, ToolStrip menuToolStrip)
        {
            _dockPanel = dockPanel;
            _windowControl = windowControl;
            _windowToolStrip = menuToolStrip;
            ToolStripContainer _windowToolStrips = new ToolStripContainer();
            _windowToolStrips.Dock = DockStyle.Fill;
            Controls.Add(_windowToolStrips);
            windowControl.Dock = DockStyle.Fill;
            _windowToolStrips.ContentPanel.Controls.Add(windowControl);
            Text = title;
            _windowID = windowID;
            if (menuToolStrip != null)
            {
                menuToolStrip.GripStyle = ToolStripGripStyle.Hidden;
                _windowToolStrips.TopToolStripPanel.Join(menuToolStrip);
                if (menuToolStrip is IStatusEventReceiver)
                {
                    ((IStatusEventReceiver)menuToolStrip).Update();
                }

            }
        }

        public override void Refresh()
        {
            IStatusEventReceiver receiver = _windowToolStrip as IStatusEventReceiver;
            if (receiver != null)
            {
                receiver.Update();
            }
            base.Refresh();
        }

        protected override string GetPersistString()
        {
            string persistString = null;
            if (_windowID != null && _windowID != Guid.Empty)
            {
                persistString = _windowID.Value.ToString("B");
            }
            return persistString;
        }

        protected override void OnClosing(System.ComponentModel.CancelEventArgs e)
        {
            _closing = true;
            base.OnClosing(e);
            if (e.Cancel)
            {
                _closing = false;
            }
        }

        void IWindow.Show(DockState state)
        {
            Show(_dockPanel, state);
        }
                
        void IWindow.Show()
        {
            if (base.DockPanel == null)
            {
                if (_defaultDockState != DockState.Hidden)
                {
                    Show(_dockPanel, _defaultDockState);
                }
            }
            else
            {
                if (this.DockState >= DockState.DockTopAutoHide &&
                    DockState <= DockState.DockRightAutoHide)
                {
                    this.DockPanel.ActiveAutoHideContent = this;
                }
                Show(_dockPanel);
            }            
        }

        bool IWindow.Close()
        {
            if (_closing == false)
            {
                Close();
            }
            return _closing;
        }
    }
}

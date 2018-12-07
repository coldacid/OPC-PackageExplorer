using System;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI;
using PackageExplorer.Services;
using System.ComponentModel;
using PackApp = PackageExplorer.ObjectModel.Application;
using PackageExplorer.Core.Services;
using PackageExplorer.Core.AddInModel.Conditions;
using System.IO;
using WinApp = System.Windows.Forms.Application;
using System.Collections.Generic;
using PackageExplorer.Core.AddInModel.Codons;
using PackageExplorer.Core.AddInModel;
using WeifenLuo.WinFormsUI.Docking;

namespace PackageExplorer.UI.Workbench.Default
{
    class DefaultWorkbench
        : Form, IWorkbench
    {
        static readonly string DockStateFile = Path.Combine(
            WinApp.LocalUserAppDataPath, "windowlayout.xml");
        WorkbenchSettings _settings = null;
        ToolStripContainer _toolstripContainer;
        DockPanel _dockPanel;
        List<ToolStrip> _toolStrips = null;
        TabWindowContextStrip _contextStrip = null;
        bool _quiting = false;

        public IWindow ActiveDocumentWindow
        {
            get
            {
                return _dockPanel.ActiveDocument as IWindow;
            }
        }

        public DefaultWorkbench()
        {
            // Initialize services
            ServiceManager.InitializeCoreServices(
                new IService[] { new MethodInvocationService(this) });
            // Create components
            InitializeComponent();
            _contextStrip = new TabWindowContextStrip();

            _toolStrips = new List<ToolStrip>();
            IToolStripService service = ServiceManager.GetService<IToolStripService>();
            foreach (ToolStrip strip in service.CreateToolStrips("/workspace/toolStrips"))
            {
                _toolStrips.Add(strip);
                _toolstripContainer.TopToolStripPanel.Join(strip);
            }
            // Application and _dockPanel do not change during app lifetime
            // anonymous method implementation used
            PackApp.Exiting +=
                delegate(object sender, EventArgs e)
                {
                    _quiting = true;
                    foreach (IDockContent content in _dockPanel.DocumentsToArray())
                    {
                        content.DockHandler.Close();
                    }
                    _dockPanel.SaveAsXml(DockStateFile);
                    Close();
                };
            _dockPanel.ActiveDocumentChanged +=
               delegate(object sender, EventArgs e)
               {
                   if (_dockPanel.ActiveDocument != null)
                   {
                       WorkbenchService workbenchService = ServiceManager.GetService<WorkbenchService>();
                       WindowManager manager = workbenchService.GetWindowManager((IWindow)_dockPanel.ActiveDocument);
                       if (manager.Source is DocumentPartContentSource)
                       {
                           ((DocumentPartContentSource)manager.Source).DocumentPart.Activate();
                       }
                   }
                   OnActiveDocumentWindowChanged(EventArgs.Empty);
                   OnActiveWindowChanged(EventArgs.Empty);
                   Refresh();
               };
            Text = Application.ProductName;
            PackApp.Documents.SelectionChanged +=
                delegate(object sender, EventArgs e)
                {
                    if (PackApp.ActiveDocument != null)
                    {
                        Text = String.Format("{0} - {1}", Application.ProductName, PackApp.ActiveDocument.Filename);
                    }
                    else
                    {
                        Text = Application.ProductName;
                    }
                };
            LoadWorkbenchSettings();
        }

        public override void Refresh()
        {
            foreach (ToolStrip strip in _toolStrips)
            {
                IStatusEventReceiver receiver = strip as IStatusEventReceiver;
                if (receiver != null)
                {
                    receiver.Update();
                }
            }
            base.Refresh();
        }

        public IWindow CreateDocumentWindow(Control content, string title)
        {
            WorkbenchWindow window = new WorkbenchWindow(
                _dockPanel, content, title, null, null);
            window.DockAreas = DockAreas.Document;
            window.TabPageContextMenuStrip = _contextStrip;
            return window;
        }

        public IWindow CreateInspectorWindow(Control content, 
            string title, Guid windowID, ToolStrip inspectorMenu)
        {
            WorkbenchWindow window = new WorkbenchWindow(
                _dockPanel, content, title, windowID, inspectorMenu);
            window.DockAreas = DockAreas.DockBottom |
                DockAreas.DockLeft |
                DockAreas.DockRight |
                DockAreas.DockTop | DockAreas.Float;
            window.HideOnClose = true;
            return window;
        }

        internal void LoadDockState()
        {
            if (File.Exists(DockStateFile))
            {
                _dockPanel.LoadFromXml(DockStateFile,
                    DeserializeDockContentFromPersistString);
            }
        }

        protected override sealed void OnClosing(CancelEventArgs e)
        {
            if (!_quiting)
            {
                FormWindowState savedState = WindowState != FormWindowState.Minimized ?
                    WindowState : FormWindowState.Normal;
                _settings.WindowState = savedState;
                PackApp.Exit();
                e.Cancel = true;
            }
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            if (this.Created == true)
            {
                if (WindowState != FormWindowState.Minimized && WindowState != FormWindowState.Maximized)
                {
                    _settings.WindowSize = Size;
                }
            }
            base.OnSizeChanged(e);
        }

        protected override void OnLocationChanged(EventArgs e)
        {
            if (Created == true)
            {
                if (WindowState != FormWindowState.Minimized && WindowState != FormWindowState.Maximized)
                {
                    _settings.WindowLocation = Location;
                }
            }
            base.OnLocationChanged(e);
        }

        protected void OnActiveWindowChanged(EventArgs e)
        {
            if (ActiveWindowChanged != null)
            {
                ActiveWindowChanged(this, e);
            }
        }

        protected void OnActiveDocumentWindowChanged(EventArgs e)
        {
            if (ActiveDocumentWindowChanged != null)
            {
                ActiveDocumentWindowChanged(this, e);
            }
        }

        void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DefaultWorkbench));
            this._toolstripContainer = new System.Windows.Forms.ToolStripContainer();
            this._dockPanel = new WeifenLuo.WinFormsUI.Docking.DockPanel();
            this._toolstripContainer.ContentPanel.SuspendLayout();
            this._toolstripContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // _toolstripContainer
            // 
            // 
            // _toolstripContainer.ContentPanel
            // 
            this._toolstripContainer.ContentPanel.Controls.Add(this._dockPanel);
            this._toolstripContainer.ContentPanel.Size = new System.Drawing.Size(784, 539);
            this._toolstripContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this._toolstripContainer.Location = new System.Drawing.Point(0, 0);
            this._toolstripContainer.Name = "_toolstripContainer";
            this._toolstripContainer.Size = new System.Drawing.Size(784, 564);
            this._toolstripContainer.TabIndex = 0;
            // 
            // _dockPanel
            // 
            this._dockPanel.ActiveAutoHideContent = null;
            this._dockPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this._dockPanel.DocumentStyle = WeifenLuo.WinFormsUI.Docking.DocumentStyle.DockingWindow;
            this._dockPanel.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World);
            this._dockPanel.Location = new System.Drawing.Point(0, 0);
            this._dockPanel.Name = "_dockPanel";
            this._dockPanel.Size = new System.Drawing.Size(784, 539);
            this._dockPanel.TabIndex = 0;
            // 
            // DefaultWorkbench
            // 
            this.ClientSize = new System.Drawing.Size(784, 564);
            this.Controls.Add(this._toolstripContainer);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "DefaultWorkbench";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this._toolstripContainer.ContentPanel.ResumeLayout(false);
            this._toolstripContainer.ResumeLayout(false);
            this._toolstripContainer.PerformLayout();
            this.ResumeLayout(false);

        }

        IDockContent DeserializeDockContentFromPersistString(
           string persistString)
        {
            WorkbenchWindow window = null;
            try
            {
                if (String.IsNullOrEmpty(persistString) == false)
                {
                    Guid windowID = new Guid(persistString);
                    if (windowID != Guid.Empty)
                    {
                        WorkbenchService service = ServiceManager.GetService<WorkbenchService>();
                        window = (WorkbenchWindow)service.GetWindow(windowID);
                    }
                }
            }
            catch
            {
            }
            return window;
        }

        void LoadWorkbenchSettings()
        {
            ISettingsService settingsService = ServiceManager.GetService<ISettingsService>();
            _settings = settingsService.GetSettings<WorkbenchSettings>();
            // Load simple settings
            Location = _settings.WindowLocation;
            Size = _settings.WindowSize;
            // Restore window state
            // Do not restore a minimized state
            FormWindowState savedState = _settings.WindowState;
            WindowState = savedState != FormWindowState.Minimized ?
                savedState : FormWindowState.Normal;
            // The first start position is centerscreen, next the 
            // saved position is used
            StartPosition = _settings.WindowStartPosition;
            if (StartPosition == FormStartPosition.CenterScreen)
            {
                _settings.WindowStartPosition = FormStartPosition.Manual;
            }
        }

        public event EventHandler ActiveWindowChanged;
        public event EventHandler ActiveDocumentWindowChanged;

        class TabWindowContextStrip
            : System.Windows.Forms.ContextMenuStrip
        {
            public TabWindowContextStrip()
            {
                Items.Add("");
            }

            protected override void OnOpening(CancelEventArgs e)
            {
                Items.Clear();
                IAddInTreeNode node = AddInTreeSingleton.AddInTree.GetTreeNode(
                    "/workspace/contextStrips/tabContextStrip");
                if (node != null)
                {
                    foreach (ToolStripItem item in node.BuildChildItems(this))
                    {
                        Items.Add(item);
                        if (item is IStatusEventReceiver)
                        {
                            ((IStatusEventReceiver)item).Update();
                        }
                    }
                }
                if (Items.Count == 0)
                {
                    e.Cancel = true;
                    Items.Add("");
                }
            }
        }

        class MethodInvocationService 
            : ServiceBase, IMethodInvocationService
        {
            Form _form = null;

            public MethodInvocationService(Form form)
            {
                _form = form;
            }

            public object Invoke(Delegate method, params object[] arguments)
            {
                return _form.Invoke(method, arguments);
            }
        }
    }
}

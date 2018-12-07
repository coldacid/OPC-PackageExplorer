using System;
using System.Windows.Forms;
using System.Threading;
using PackageExplorer.Core.AddInModel;
using System.Collections;
using PackageExplorer.Core.AddInModel.Codons;
using PackageExplorer.Core;
using System.IO;
using PackageExplorer.Core.Services;
using PackApp = PackageExplorer.ObjectModel.Application;
using PackageExplorer.UI.Workbench;
namespace PackageExplorer
{
    class PackageExplorerContext
        : ApplicationContext
    {
        delegate void SafeReportStatusCallback(string status);
        delegate void ApplicationRunCallback();

        Type _splashFormType = null; // first thread
        int _minimalSplashDuration; // first thread
        AutoResetEvent _initReadyEvent = null; // first thread, init thread, nolock

        public int MinimalSplashDuration
        {
            get { return _minimalSplashDuration; }
        }

        public PackageExplorerContext(Type splashFormType,
            int minimalSplashDuration)
            : base()
        {
            if (minimalSplashDuration < 0)
            {
                _minimalSplashDuration = 0;
            }
            else
            {
                _minimalSplashDuration = minimalSplashDuration;
            }
            _splashFormType = splashFormType;
        }

        public void Run(string[] args)
        {
            Thread.CurrentThread.Name = "Initial Thread";
            // Create waithandle for minimum splash duration
            _initReadyEvent = new AutoResetEvent(false);
            // Create the ui thread and start it, 
            // displays the splash screen on its own thread
            Thread uiThread = new Thread(RunApplicationThreadMethod);
            uiThread.Name = "UI Thread";
            uiThread.SetApartmentState(ApartmentState.STA);
            uiThread.Start(_splashFormType);
            // Fire up initialization thread
            Thread initializationThread = new Thread(
                InitializeApplicationThreadMethod);
            initializationThread.Name = "Init Thread";
            initializationThread.Start(args);
            // now wait for minimum duration
            if (_minimalSplashDuration > 0)
            {
                Thread.Sleep(_minimalSplashDuration);
            }
            // now wait for init to complete
            if (_initReadyEvent.WaitOne(
                new TimeSpan(0, 5, 0), false) == false)
            {
                throw new PackageExplorerException("Initialization took to long, aborting");
            }
            // Toggle to main form
            MainForm.Invoke(
                new ApplicationRunCallback(ToggleToMainForm));
        }

        void RunApplicationThreadMethod(object splashFormType)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Form splashForm = (Form)Activator.CreateInstance((Type)splashFormType);
            MainForm = splashForm;
            Application.Run(this);
        }

        void InitializeApplicationThreadMethod(object argsObject)
        {
            string[] args = argsObject as string[];
            // Initialize Add-In Tree
            AddInTreeSingleton.LoadAddInDirectory(
                Path.Combine(Application.StartupPath, "AddIns"));
            IAddInTreeNode servicesNode =
                AddInTreeSingleton.AddInTree.GetTreeNode("/workspace/services");
            if (servicesNode != null)
            {
                ArrayList services = servicesNode.BuildChildItems(null);
                ServiceManager.InitializeCoreServices(services);
            }

            if (args != null && args.Length > 0)
            {
                for (int i = 0; i < args.Length; i++)
                {
                    if (File.Exists(args[i]))
                    {
                        PackApp.Documents.Open(args[i]);
                    }
                }
            }
            _initReadyEvent.Set();
        }

        void ToggleToMainForm()
        {
            IAddInTreeNode autoStartCommandsNode =
                AddInTreeSingleton.AddInTree.GetTreeNode(
                    "/workspace/autoStartCommands");
            ArrayList commands = autoStartCommandsNode.BuildChildItems(null);
            foreach (ICommand command in commands)
            {
                command.Execute();
            }
            Form splashForm = MainForm;
            Form workbench = (Form)WorkbenchSingleton.DefaultWorkbench;
            MainForm = workbench;
            MainForm.Shown +=
                delegate(object sender, EventArgs e)
                {
                    splashForm.Close();
                };
            MainForm.Show();
        }
    }
}

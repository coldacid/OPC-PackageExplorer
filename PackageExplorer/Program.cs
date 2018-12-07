#region [===== Using =====]
using System;
using System.Windows.Forms;
using System.Threading;
using PackageExplorer.UI.Controls;
using PackageExplorer.UI.Dialogs;
using PackageExplorer.Core.AddInModel;
using System.IO;
using System.Collections;
using PackageExplorer.Core.Services;
using PackApp = PackageExplorer.ObjectModel.Application;
using PackageExplorer.Core.AddInModel.Codons;
using PackageExplorer.UI.Workbench;
using System.Text;
#endregion

namespace PackageExplorer
{
    static partial class Program
    {
        #region [===== Main Method =====]
        [STAThread]
        static void Main(string[] args)
        {
            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);
            Application.ThreadException += Application_ThreadException;
            try
            {
                SplashScreenContext context = new SplashScreenContext();
                context.MinimumSplashDuration = 1500;
                context.Run(args,
                    typeof(SplashScreen), 
                    ApplicationInit,
                    UIInit);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }   
        }
        #endregion

        #region [===== Private static methods =====]
        static void ApplicationInit(string[] args, 
            PackageExplorer.SplashScreenContext.SafeSendMessageCallback messageCallback)
        {
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
            
        }

        static Form UIInit(string[] args, 
            PackageExplorer.SplashScreenContext.SafeSendMessageCallback messageCallback)
        {            
            IWorkbench workbench = WorkbenchSingleton.DefaultWorkbench;
            Form workbenchForm = (Form)workbench;
            Application.AddMessageFilter(new WindowPickerMessageFilter(workbenchForm));
            return workbenchForm;
        }

        static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            DisplayErrorAndExit((Exception)e.ExceptionObject);
        }

        static void Application_ThreadException(
            object sender, ThreadExceptionEventArgs e)
        {
            DisplayErrorAndExit(e.Exception);
        }

        static void DisplayErrorAndExit(Exception e)
        {
            try
            {
                ErrorDialog dialog = new ErrorDialog(e);
                dialog.ShowDialog();
            }
            catch (Exception)
            {
            }
            System.Windows.Forms.Application.Exit();
        }
        #endregion
    }
}
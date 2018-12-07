using System;

namespace PackageExplorer.UI.Workbench
{
    public interface IWorkbenchLoader
    {
        IWorkbench CreateWorkbench();
        void InitializeWorkbench(bool firstTimeStartup);
    }
}

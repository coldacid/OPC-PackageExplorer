using System;
using PackageExplorer.Core.AddInModel;
using PackageExplorer.Services;
using PackageExplorer.Core.Services;
using PackageExplorer.Core.AddInModel.Conditions;
using PackageExplorer.ObjectModel;

namespace PackageExplorer.UI.Workbench
{
    public static class WorkbenchSingleton
    {
        static WorkbenchService _workbenchService = null;

        public static IWorkbench DefaultWorkbench
        {
            get { return _workbenchService.DefaultWorkbench; }
        }

        static WorkbenchSingleton()
        {
            _workbenchService = ServiceManager.GetService<WorkbenchService>();
            Application.Documents.SelectionChanged += new EventHandler<EventArgs>(Documents_SelectionChanged);
        }

        static void Documents_SelectionChanged(object sender, EventArgs e)
        {
            _workbenchService.DefaultWorkbench.Refresh();
        }
    }
}

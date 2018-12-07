using System;
using PackageExplorer.Core.AddInModel.Conditions;
using PackageExplorer.Services;
using PackageExplorer.Core.Services;

namespace PackageExplorer.UI.Workbench
{
    [ConditionName("HasDirtyOpenTab")]
    public class HasDirtyOpenTabCondition
        : ConditionBase
    {
        public override bool IsValid(object caller)
        {
            bool hasDirtyTab = false;
            IWindow window = WorkbenchSingleton.DefaultWorkbench.ActiveDocumentWindow;
            if (window != null)
            {
                WorkbenchService service = ServiceManager.GetService<WorkbenchService>();
                WindowManager manager = service.GetWindowManager(window);
                hasDirtyTab = manager != null && manager.IsDirty;
            }
            return hasDirtyTab;
        }
    }
}

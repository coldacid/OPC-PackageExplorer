using System;
using PackageExplorer.UI.Workbench;
using PackageExplorer.Core.AddInModel.Conditions;
using PackageExplorer.Services;
using PackageExplorer.Core.Services;

namespace PackageExplorer.UI.Workbench
{
    [ConditionName("HasEditableOpenTab")]
    public class HasEditableOpenTabCondition
        : ConditionBase
    {
        public override bool IsValid(object caller)
        {
            bool hasEditableTab = false;
            IWindow window = WorkbenchSingleton.DefaultWorkbench.ActiveDocumentWindow;
            if (window != null)
            {
                WorkbenchService service = ServiceManager.GetService<WorkbenchService>();
                WindowManager manager = service.GetWindowManager(window);                
                hasEditableTab = manager != null && manager.IsReadOnly == false;
            }
            return hasEditableTab;
        }
    }
}

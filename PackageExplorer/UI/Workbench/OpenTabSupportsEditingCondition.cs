using System;
using PackageExplorer.Core.AddInModel.Conditions;
using PackageExplorer.Services;
using PackageExplorer.Core.Services;

namespace PackageExplorer.UI.Workbench
{
    [ConditionName("OpenTabSupportsEditing")]
    public class OpenTabSupportsEditingCondition
        : ConditionBase
    {
        public override bool IsValid(object caller)
        {
            WorkbenchService service = ServiceManager.GetService<WorkbenchService>();
            if (service.DefaultWorkbench.ActiveDocumentWindow != null)
            {
                WindowManager mgr = service.GetWindowManager(service.DefaultWorkbench.ActiveDocumentWindow);
                return mgr.Editor as ISupportEditing != null;
            }
            return false;
        }
    }
}

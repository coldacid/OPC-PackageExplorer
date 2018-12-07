using System;
using PackageExplorer.Core.AddInModel.Conditions;
using PackageExplorer.Services;
using PackageExplorer.Core.Services;
using PackageExplorer.Utils;

namespace PackageExplorer.UI.Workbench
{
    [ConditionName("HasEditableXmlOpenTab")]
    class HasEditableXmlOpenTabCondition
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
                if (manager != null)
                {
                    hasEditableTab =
                        (manager.ContentType & ContentTypes.Xml) == ContentTypes.Xml &&
                        manager.IsReadOnly == false;
                }
            }
            return hasEditableTab;
        }
    }
}

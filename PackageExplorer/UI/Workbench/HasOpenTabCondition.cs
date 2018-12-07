using System;
using PackageExplorer.Core.AddInModel.Conditions;

namespace PackageExplorer.UI.Workbench
{
    [ConditionName("HasOpenTab")]
    class HasOpenTabCondition
        : ConditionBase
    {
        private int _tabCount = 1;

        public int TabCount
        {
            get { return _tabCount; }
            set { _tabCount = value; }
        }

        public override bool IsValid(object caller)
        {
            return WorkbenchSingleton.DefaultWorkbench.ActiveDocumentWindow != null;
        }
    }
}

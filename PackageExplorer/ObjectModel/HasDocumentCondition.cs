using System;
using PackageExplorer.Core.AddInModel.Conditions;

namespace PackageExplorer.ObjectModel
{
    [ConditionName("HasDocument")]
    class HasDocumentCondition
        : ConditionBase
    {
        public HasDocumentCondition()
        {
        }

        public override bool IsValid(object caller)
        {
            return Application.ActiveDocument != null;
        }
    }
}

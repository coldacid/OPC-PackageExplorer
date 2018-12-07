using System;
using PackageExplorer.Core.AddInModel.Conditions;

namespace PackageExplorer.ObjectModel
{
    [ConditionName("HasPackagingErrors")]
    class HasPackagingErrorsCondition
        : ConditionBase
    {
        public override bool IsValid(object caller)
        {
            bool hasErrors = false;
            Document document = Application.ActiveDocument;
            if (document != null)
            {
                hasErrors = document.PackagingErrors.Count > 0;
            }
            return hasErrors;
        }
    }
}

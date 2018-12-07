using System;
using PackageExplorer.Core.AddInModel.Conditions;
using WinApp = System.Windows.Forms.Application;
using System.IO;

namespace PackageExplorer.AddIns.ValidationInspector
{
    [ConditionName("HasValidationPackages")]
    public class HasValidationPackagesCondition
        : ConditionBase
    {
        public override bool IsValid(object caller)
        {
            return Directory.GetFiles(DefaultValidationService.ValidationPackageFolder, "*.zip").Length > 0;
        }
    }
}

using System;
using PackageExplorer.Core.AddInModel.Conditions;
using PackageExplorer.Services;
using PackageExplorer.Core.Services;
using PackageExplorer.UI.Workbench;

namespace PackageExplorer.AddIns.DocumentInspector
{
    [ConditionName("FlatModeState")]
    class FlatModeStateCondition
        : ConditionBase
    {
        bool _flatModeEnabled = false;

        public bool FlatModeEnabled
        {
            get { return _flatModeEnabled; }
            set { _flatModeEnabled = value; }
        }

        public override bool IsValid(object caller)
        {
            WorkbenchService service = ServiceManager.GetService<WorkbenchService>();
            IWindow window = service.GetWindow(DocumentInspectorControl.ID);
            DocumentInspectorControl control = (DocumentInspectorControl)window.WindowControl;
            return control.FlatMode == _flatModeEnabled;
        }
    }
}

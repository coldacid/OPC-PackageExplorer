using System;
using PackageExplorer.Core.AddInModel.Conditions;
using PackageExplorer.Services;
using PackageExplorer.UI.Workbench;
using PackageExplorer.AddIns.DocumentInspector;
using PackageExplorer.Core.Services;

namespace PackageExplorer.AddIns.DocumentFactory
{
    [ConditionName("HasVocabulary")]
    class HasVocabularyCondition
        : ConditionBase
    {
        public override bool IsValid(object caller)
        {
            bool hasVocabulary = false;
            WorkbenchService workbenchService = ServiceManager.GetService<WorkbenchService>();
            IWindow window = workbenchService.GetWindow(DocumentInspectorControl.ID);
            DocumentInspectorControl control = (DocumentInspectorControl)window.WindowControl;
            if (control.SelectedNode != null)
            {
                if (control.SelectedNode is DocumentNode)
                {
                    hasVocabulary = ((DocumentNode)control.SelectedNode).Document.Vocabulary != null;
                }
                else if (control.SelectedNode is DocumentPartNode)
                {
                    hasVocabulary = ((DocumentPartNode)control.SelectedNode).DocumentPart.VocabularyPart != null;
                }
            }
            return hasVocabulary;
        }
    }
}

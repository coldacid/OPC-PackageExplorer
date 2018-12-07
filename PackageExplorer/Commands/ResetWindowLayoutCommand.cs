using System;
using PackageExplorer.Services;
using PackageExplorer.Core.Services;
using PackageExplorer.Core.AddInModel;
using PackageExplorer.UI.Workbench;
using PackageExplorer.UI.Workbench.Default;
using WeifenLuo.WinFormsUI.Docking;

namespace PackageExplorer.Commands
{
    class ResetWindowLayoutCommand
        : CommandBase
    {
        public ResetWindowLayoutCommand()
            : base("Window.ResetLayout")
        {
        }

        public override void Execute()
        {
            IAddInTreeNode node = AddInTreeSingleton.AddInTree.GetTreeNode("/workspace/inspectors");
            if (node != null)
            {
                WorkbenchService service = ServiceManager.GetService<WorkbenchService>();
                foreach(IAddInTreeNode inspectorNode in node.ChildNodes)
                {
                    InspectorCodon codon = inspectorNode.Codon as InspectorCodon;
                    
                    IWindow window = service.GetWindow(codon.InspectorID);
                    if(codon.StartupDockState != DockState.Hidden)
                    {
                        window.Show(codon.StartupDockState);
                    }
                    else
                    {
                        window.Hide();
                    }
                }
            }
        }        
    }
}

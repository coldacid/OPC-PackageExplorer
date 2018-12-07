using System;
using PackageExplorer.Core.AddInModel;
using PackageExplorer.Services;
using PackageExplorer.Core.Services;
using PackageExplorer.UI.Menu;
using WeifenLuo.WinFormsUI.Docking;
using System.Collections;
using PackageExplorer.Core.AddInModel.Codons;

namespace PackageExplorer.UI.Workbench.Default
{
    class DefaultWorkbenchLoader
        : IWorkbenchLoader
    {
        public IWorkbench CreateWorkbench()
        {
            DefaultWorkbench wb =  new DefaultWorkbench();
            wb.Load += new EventHandler(wb_Load);
            return wb;
        }

        void wb_Load(object sender, EventArgs e)
        {
            LoadLastInspectorLayout();
            IAddInTreeNode autoStartCommandsNode =
                AddInTreeSingleton.AddInTree.GetTreeNode(
                    "/workspace/autoStartCommands");
            ArrayList commands = autoStartCommandsNode.BuildChildItems(null);
            foreach (ICommand command in commands)
            {
                command.Execute();
            }
            WorkbenchSingleton.DefaultWorkbench.Refresh();
        }

        public void InitializeWorkbench(bool firstTimeStartup)
        {
            CreateInspectorWindows();
            if (firstTimeStartup)
            {
                DisplayInitialInspectors();
            }
        }

        void CreateInspectorWindows()
        {
            IAddInTreeNode node = AddInTreeSingleton.AddInTree.GetTreeNode("/workspace/inspectors");
            if (node != null)
            {
                WorkbenchService service = ServiceManager.GetService<WorkbenchService>();
                StringParserService parser = ServiceManager.GetService<StringParserService>();
                foreach (IAddInTreeNode inspectorNode in node.ChildNodes)
                {
                    InspectorCodon codon = inspectorNode.Codon as InspectorCodon;
                    ToolStrip strip = null;
                    if (String.IsNullOrEmpty(codon.InspectorMenuTreePath) == false)
                    {
                        IAddInTreeNode toolStripNode =
                            AddInTreeSingleton.AddInTree.GetTreeNode(codon.InspectorMenuTreePath);
                        if (toolStripNode == null)
                        {
                            // defined node does not exist
                            throw new Exception();
                        }
                        if (toolStripNode.Codon is ToolStripCodon == false)
                        {
                            throw new Exception();
                        }
                        strip = (ToolStrip)toolStripNode.BuildItem(null);
                    }
                    IWindow window = service.CreateInspectorWindow((IContentExplorer)inspectorNode.BuildItem(this),
                        parser.Parse(codon.Title), strip);
                    ((WorkbenchWindow)window).DefaultDockState = codon.DefaultDockState;
                }
            }
        }
        
        void DisplayInitialInspectors()
        {
            IAddInTreeNode node = AddInTreeSingleton.AddInTree.GetTreeNode("/workspace/inspectors");
            if (node != null)
            {
                WorkbenchService service = ServiceManager.GetService<WorkbenchService>();
                foreach (IAddInTreeNode inspectorNode in node.ChildNodes)
                {
                    InspectorCodon codon = inspectorNode.Codon as InspectorCodon;

                    IWindow window = service.GetWindow(codon.InspectorID);
                    if (codon.StartupDockState != DockState.Hidden)
                    {
                        window.Show(codon.StartupDockState);
                    }
                }
            }
        }

        void LoadLastInspectorLayout()
        {
            ((DefaultWorkbench)WorkbenchSingleton.DefaultWorkbench).LoadDockState();
        }
    }
}

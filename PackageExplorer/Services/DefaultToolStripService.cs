using System;
using PackageExplorer.Core.Services;
using System.Collections.Generic;
using PackageExplorer.UI.Menu;
using PackageExplorer.Core.AddInModel;
using ToolStrip = System.Windows.Forms.ToolStrip;

namespace PackageExplorer.Services
{
    class DefaultToolStripService
        : ServiceBase, IToolStripService
    {
        public List<ToolStrip> CreateToolStrips(string treePath)
        {
            List<ToolStrip>  _strips = new List<ToolStrip>();
            IAddInTreeNode toolStripsNode =
                AddInTreeSingleton.AddInTree.GetTreeNode(
                    treePath);
            foreach (ToolStrip strip in toolStripsNode.BuildChildItems(this))
            {
                _strips.Add(strip);
            }
            return _strips;
        }
    }
}

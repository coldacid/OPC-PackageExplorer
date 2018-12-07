namespace PackageExplorer.AddIns.AddInScout
{
	using System;
	using System.Collections.Generic;
	using System.ComponentModel;
	using System.Drawing;
	using System.Data;
	using System.Text;
	using System.Windows.Forms;
    using PackageExplorer.Core.AddInModel;
    using PackageExplorer.Core.AddInModel.Codons;
    using PackageExplorer.Core.AddInModel.Conditions;
	using System.Collections;

	public partial class ExtensionTreeView : TreeView
	{
		private bool _displayLeafLevel = false;

		[DefaultValue(false)]
		[Category("Appearance")]
		[Description("Indicates whether to display leaf level (childless) nodes.")]
		public bool DisplayLeafLevel
		{
			get { return _displayLeafLevel; }
			set { _displayLeafLevel = value; }
		}

		public ExtensionTreeView()
		{
		}

		protected override void OnCreateControl()
		{
			TreeNode root = new TreeNode("AddInTree");
			root.Tag = AddInTreeSingleton.AddInTree.Root;
			ParseTreeNode(AddInTreeSingleton.AddInTree.Root, root);
			Nodes.Add(root);
			base.OnCreateControl();
		}

		void ParseTreeNode(IAddInTreeNode addInNode, TreeNode treeNode)
		{
            foreach (IAddInTreeNode node in addInNode.ChildNodes)
            {
                if (node.Count > 0)
                {
                    TreeNode childTreeNode = new TreeNode(node.NodeName);
                    childTreeNode.Tag = node;
                    treeNode.Nodes.Add(childTreeNode);
                    ParseTreeNode(node, childTreeNode);
                }
            }
		}
	}
}

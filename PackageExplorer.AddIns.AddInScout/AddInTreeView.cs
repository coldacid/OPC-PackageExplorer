using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using PackageExplorer.Core.AddInModel;
using PackageExplorer.Core.AddInModel.Codons;

namespace PackageExplorer.AddIns.AddInScout
{
	public partial class AddInTreeView : TreeView
	{
		public AddInTreeView()
		{
		}

		protected override void OnCreateControl()
		{
			TreeNode root = new TreeNode("AddIns");
			root.Tag = null;
			foreach (AddIn addIn in AddInTreeSingleton.AddInTree.AddIns)
			{
				ParseAddIn(addIn, root);
			}
			Nodes.Add(root);
			base.OnCreateControl();
		}

		void ParseAddIn(AddIn addIn, TreeNode root)
		{
			TreeNode addInNode = new TreeNode(addIn.Name);
			foreach (Extension extension in addIn.Extensions)
			{
				TreeNode extensionNode = new TreeNode(extension.Path.ToString());
				extensionNode.Tag = extension;
				addInNode.Nodes.Add(extensionNode);
			}
			root.Nodes.Add(addInNode);
		}

	}
}

using System;
using System.Windows.Forms;
using PackageExplorer.Core.AddInModel;
using System.Linq;
namespace PackageExplorer.AddIns.AddInScout
{
	public partial class AddInScout : UserControl
	{
		ExtensionTreeView _extensionTree = null;
		AddInTreeView _addInTree = null;
		ExtensionDetailsPanel _extensionPanel = null;
		AddInDetailsPanel _addInDetailsPanel = null;

		public AddInScout()
		{
			InitializeComponent();

			_extensionTree = new ExtensionTreeView();
			_extensionTree.Dock = DockStyle.Fill;
            _extensionTree.DisplayLeafLevel = true;
			_extensionTree.AfterSelect += new TreeViewEventHandler(ExtensionTreeView_AfterSelect);
			_treeViewTab.Controls.Add(_extensionTree);

			_addInTree = new AddInTreeView();
			_addInTree.Dock = DockStyle.Fill;
			_addInTree.AfterSelect += new TreeViewEventHandler(AddInTreeView_AfterSelect);
			_listViewTab.Controls.Add(_addInTree);

			_extensionPanel = new ExtensionDetailsPanel();
			_extensionPanel.Dock = DockStyle.Fill;
			_extensionPanel.SelectedIndexChanged += new EventHandler(ExtensionPanel_SelectedIndexChanged);
			_horizontalSplitter.Panel2.Controls.Add(_extensionPanel);

			_addInDetailsPanel = new AddInDetailsPanel();
			_addInDetailsPanel.Dock = DockStyle.Fill;
			_horizontalSplitter.Panel1.Controls.Add(_addInDetailsPanel);
		}

		void ExtensionTreeView_AfterSelect(object sender, TreeViewEventArgs e)
		{
			IAddInTreeNode selectedNode = e.Node.Tag as IAddInTreeNode;;
			if (selectedNode.Extension != null)
			{
                _extensionPanel.SelectExtension(selectedNode.Extension.Path,
                    selectedNode.ChildNodes.Select(
                        treeNode => treeNode.Codon));
			}
		}

		void AddInTreeView_AfterSelect(object sender, TreeViewEventArgs e)
		{
			Extension extension = _addInTree.SelectedNode.Tag as Extension;
			if (extension != null)
			{
				_extensionPanel.SelectExtension(extension.Path, extension.Codons);
			}
		}

		void ExtensionPanel_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (_extensionPanel.SelectedItem != null)
			{
				_addInDetailsPanel.SelectObject(_extensionPanel.SelectedItem.AddIn);
			}
		}

	}
}

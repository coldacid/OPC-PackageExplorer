using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using PackageExplorer.Core.AddInModel;
using PackageExplorer.Core;
using PackageExplorer.Core.Services;

namespace PackageExplorer.UI.Dialogs
{
    public partial class OptionsDialog 
        : DialogContent
    {
        List<PropertyPanel> _openedDialogs = null;

        public override bool ValidOnLoad
        {
            get { return true; }
        }

        public OptionsDialog()
        {
            _openedDialogs = new List<PropertyPanel>();
            InitializeComponent();
        }

        public void SaveChanges()
        {
            foreach (PropertyPanel optionPanel in _openedDialogs)
            {
                if (optionPanel.IsDirty)
                {
                    optionPanel.ApplyChanges();
                }
            }
        }

        protected override void OnLoad(EventArgs e)
        {
            IAddInTreeNode optionPanelsNode =
                AddInTreeSingleton.AddInTree.GetTreeNode(
                    "/workspace/optionPanels");
            if (optionPanelsNode != null)
            {
                foreach (IAddInTreeNode optionPanelNode in
                    optionPanelsNode.ChildNodes)
                {
                    OptionPanelTreeNode treeNode = BuildOptionsPanelTree(optionPanelNode);
                    _optionGroupsTreeView.Nodes.Add(treeNode);
                }
            }
            base.OnLoad(e);
        }

        void OptionGroupsTreeView_AfterSelect(
            object sender, TreeViewEventArgs e)
        {
            SelectOptionPanel(((OptionPanelTreeNode)e.Node).CorrespondingDialog);
        }

        private void SelectOptionPanel(PropertyPanel dialog)
        {
            if (dialog != null)
            {
                if (_openedDialogs.Contains(dialog) == false)
                {
                    _openedDialogs.Add(dialog);
                }
                try
                {
                    _mainContainer.Panel2.SuspendLayout();
                    _mainContainer.Panel2.Controls.Clear();
                    dialog.Dock = DockStyle.Fill;
                    _mainContainer.Panel2.Controls.Add(dialog);
                }
                finally
                {
                    _mainContainer.Panel2.ResumeLayout(false);
                    _mainContainer.Panel2.PerformLayout();
                }
            }
        }

        OptionPanelTreeNode BuildOptionsPanelTree(IAddInTreeNode optionPanelNode)
        {
            OptionPanelCodon codon = optionPanelNode.Codon as OptionPanelCodon;
            if (codon == null)
            {
                throw new PackageExplorerException("Option panel node without codon defined");
            }
            OptionPanelTreeNode node = null;
            if (String.IsNullOrEmpty(codon.Class) == false)
            {
                node = new OptionPanelTreeNode(codon, (PropertyPanel)codon.BuildItem(this, null));
            }
            else
            {
                node = new OptionPanelTreeNode(codon);
            }
            StringParserService parser = ServiceManager.GetService<StringParserService>();
            node.Text = parser.Parse(codon.Title);
            foreach (IAddInTreeNode childAddInTreeNode in optionPanelNode.ChildNodes)
            {
                OptionPanelTreeNode childPanelNode = BuildOptionsPanelTree(childAddInTreeNode);
                if (childPanelNode.Codon.ID == codon.DefaultChildPane)
                {
                    node.CorrespondingDialog = childPanelNode.CorrespondingDialog;
                }
                node.Nodes.Add(childPanelNode);
            }
            return node;
        }

        class OptionPanelTreeNode
            : TreeNode
        {
            PropertyPanel _correspondingDialog = null;
            OptionPanelCodon _codon;
            
            public OptionPanelCodon Codon
            {
                get { return _codon; }
            }

            public PropertyPanel CorrespondingDialog
            {
                get { return _correspondingDialog; }
                set { _correspondingDialog = value; }
            }

            public OptionPanelTreeNode(OptionPanelCodon codon)
                : this(codon, null)
            {
            }

            public OptionPanelTreeNode(OptionPanelCodon codon, 
                PropertyPanel correspondingDialog)
            {
                _codon = codon;
                _correspondingDialog = correspondingDialog;
            }
        }
    }
}

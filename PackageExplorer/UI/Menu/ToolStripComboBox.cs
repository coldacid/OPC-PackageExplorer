using System;
using PackageExplorer.Core.AddInModel.Codons;
using PackageExplorer.Core.AddInModel.Conditions;
using PackageExplorer.Services;
using PackageExplorer.Core.Services;
using System.Linq;

namespace PackageExplorer.UI.Menu
{
    public class ToolStripComboBox
        : System.Windows.Forms.ToolStripComboBox,
        IStatusEventReceiver
    {
        internal ToolStripComboBoxCodon Codon { get; set; }
        public string SelectionGroup { get; set; }
        public object Caller { get; set; }

        void IStatusEventReceiver.Update()
        {
            ConditionFailedAction action =
                Codon.GetConditionFailedAction(Caller);
            Visible = action != ConditionFailedAction.Exclude;
            Enabled = action != ConditionFailedAction.Disable;

            if (SelectionGroup != null)
            {
                ISelectionService selectionService = ServiceManager.GetService<ISelectionService>();
                string selection = (string)selectionService.GetSelectionForGroup(SelectionGroup);
                if (selection != null)
                {
                    ToolStripComboBoxItem selectedItem = this.Items.Cast<ToolStripComboBoxItem>().Where(
                        item => item.Title == selection).FirstOrDefault();
                    SelectedItem = selectedItem;
                }
                else
                {
                    SelectedIndex = -1;
                }
            }
        }
    }
}

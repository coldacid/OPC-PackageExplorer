using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using PackageExplorer.Core.Services;
using PackageExplorer.Core.AddInModel.Codons;
using PackageExplorer.Core.AddInModel;

namespace PackageExplorer.UI.Menu
{
    [CodonName("ToolStripComboBox")]
    public class ToolStripComboBoxCodon
        : CodonBase
    {
        public string SelectionGroup { get; set; }
        public int DropDownWidth { get; set; }

        public override object BuildItem(object owner,
            ArrayList subItems)
        {
            ToolStripComboBox comboBox = new ToolStripComboBox()
            {
                SelectionGroup = SelectionGroup,
                Codon = this
            };
            comboBox.ComboBox.DisplayMember = "Title";
            if (DropDownWidth != 0)
            {
                comboBox.ComboBox.DropDownWidth = DropDownWidth;
            }
            comboBox.ComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            foreach (object item in subItems)
            {
                if (item is IComboBoxBuilder)
                {
                    foreach (ToolStripComboBoxItem comboBoxItem in
                        ((IComboBoxBuilder)item).BuildComboBox())
                    {
                        comboBox.Items.Add(comboBoxItem);
                    }
                }
                else
                {
                    comboBox.Items.Add((ToolStripComboBoxItem)item);
                }
            }
            ((IStatusEventReceiver)comboBox).Update();
            comboBox.SelectedIndexChanged +=
                delegate(object sender, EventArgs e)
                {
                    ((ToolStripComboBoxItem)comboBox.SelectedItem).Command.Execute();
                };
            return comboBox;
        }
    }
}

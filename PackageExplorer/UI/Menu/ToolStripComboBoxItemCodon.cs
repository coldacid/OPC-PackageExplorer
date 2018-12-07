using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using PackageExplorer.Core.Services;
using PackageExplorer.Core.AddInModel.Codons;
using PackageExplorer.Core.AddInModel;

namespace PackageExplorer.UI.Menu
{
    [CodonName("ToolStripComboBoxItem")]
    [RequiredAttribute("title")]
    [RequiredAttribute("commandName")]
    public class ToolStripComboBoxItemCodon
        : CodonBase
    {
        public string Title { get; set; }
        public string CommandName { get; set; }

        public override object BuildItem(object owner,
            ArrayList subItems)
        {
            return new ToolStripComboBoxItem() { Title = Title, CommandName = CommandName };
        }
    }
}
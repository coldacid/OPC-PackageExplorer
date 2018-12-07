using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Windows.Forms;
using PackageExplorer.Core.Services;
using PackageExplorer.Core.AddInModel.Codons;
using PackageExplorer.Core.AddInModel;

namespace PackageExplorer.UI.Menu
{
    [CodonName("ToolStripDropDown")]
    [RequiredAttribute("title")]
    class ToolStripDropDownCodon
        : CodonBase
    {
        string _title;
        ToolStripItemDisplayStyle _displayStyle = ToolStripItemDisplayStyle.Text;
        string _iconResource;

        public string IconResource
        {
            get { return _iconResource; }
            set { _iconResource = value; }
        }

        public ToolStripItemDisplayStyle DisplayStyle
        {
            get { return _displayStyle; }
            set { _displayStyle = value; }
        }

        public string Title
        {
            get { return _title; }
            set { _title = value; }
        }

        public override object BuildItem(object owner, 
            ArrayList subItems)
        {
            ToolStripDropDownButton dropDown = new ToolStripDropDownButton(
                this, owner);
            foreach(ToolStripItem item in subItems)
            {
                dropDown.DropDownItems.Add(item);
            }
            return dropDown;
        }
    }
}

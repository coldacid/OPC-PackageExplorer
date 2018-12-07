using System;
using PackageExplorer.Core.AddInModel.Codons;
using System.Windows.Forms;
using PackageExplorer.Core.AddInModel;
using System.Collections;

namespace PackageExplorer.UI.Menu
{
    [CodonName("ToolStripMenuItem")]
    [RequiredAttribute("title")]
    class ToolStripMenuItemCodon
        : CodonBase
    {
        string _title;
        string _commandName;
        string _iconResource;
        Keys _shortcutKeys = Keys.None;
        ToolStripItemDisplayStyle _displayStyle = ToolStripItemDisplayStyle.ImageAndText;
        bool _isCheckable = false;
        
        public bool IsCheckable
        {
            get { return _isCheckable; }
            set { _isCheckable = value; }
        }

        public string IconResource
        {
            get { return _iconResource; }
            set { _iconResource = value; }
        }

        public Keys ShortcutKeys
        {
            get { return _shortcutKeys; }
            set { _shortcutKeys = value; }
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
        
        public string CommandName
        {
            get { return _commandName; }
            set { _commandName = value; }
        }

        public override bool HandlesConditions
        {
            get { return true; }
        }

        public override object BuildItem(object owner,
            ArrayList subItems)
        {
            ToolStripMenuItem item = null;
            if (_isCheckable == false)
            {
                item = new ToolStripMenuItem(this, owner, subItems);
            }
            else
            {
                item = new CheckableToolStripMenuItem(this, owner, subItems);
            }
            item.Tag = owner;
            return item;
        }
    }
}
using System;
using System.Windows.Forms;
using PackageExplorer.Core.Services;
using System.Collections;
using PackageExplorer.Core.AddInModel.Codons;
using PackageExplorer.Core.AddInModel.Conditions;
using Application = PackageExplorer.ObjectModel.Application;
namespace PackageExplorer.UI.Menu
{
    public class ToolStripMenuItem : 
        System.Windows.Forms.ToolStripMenuItem, IStatusEventReceiver
    {
        ToolStripMenuItemCodon _menuItemCodon = null;
        object _caller = null;
        ArrayList _subItems = null;

        ICommand _menuCommand = null;
        bool _hasMenuBuilder = false;

        public ICommand MenuCommand
        {
            get
            {
                if (_menuCommand == null)
                {
                    if (String.IsNullOrEmpty(_menuItemCodon.CommandName) == false)
                    {
                        _menuCommand = Application.Commands[_menuItemCodon.CommandName];
                    }
                }
                return _menuCommand;
            }
        }

        internal ToolStripMenuItem(ToolStripMenuItemCodon codon, object caller,
            ArrayList subItems)
        {
            _menuItemCodon = codon;
            _caller = caller;
            _subItems = subItems;
            foreach (object item in _subItems)
            {
                if (item is ISubMenuBuilder)
                {
                    _hasMenuBuilder = true;
                }
            }
            RecreateMenu();
        }

        public ToolStripMenuItem(string title, IMenuCommand command)
        {
            _menuCommand = command;
            Text = title;
        }

        protected override void OnClick(EventArgs e)
        {
            ICommand command = MenuCommand;
            if (command != null)
            {
                command.Execute();
            }
            base.OnClick(e);
        }

        void IStatusEventReceiver.Update()
        {
            UpdateMenuItem();
        }

        protected virtual void UpdateMenuItem()
        {
            if (_menuItemCodon != null && _hasMenuBuilder)
            {
                RecreateMenu();
            }
            RefreshMenu();
        }

        void RecreateMenu()
        {
            this.DropDownItems.Clear();
            foreach (object subItem in _subItems)
            {
                if (subItem is ToolStripItem)
                {
                    DropDownItems.Add((ToolStripItem)subItem);
                }
                else if (subItem is ISubMenuBuilder)
                {
                    foreach (ToolStripMenuItem builderItem in
                        ((ISubMenuBuilder)subItem).BuildSubMenu())
                    {
                        DropDownItems.Add(builderItem);
                    }
                }
            }
        }

        private void RefreshMenu()
        {
            if (_menuItemCodon != null)
            {
                StringParserService stringParser = ServiceManager.GetService<StringParserService>();
                Text = stringParser.Parse(_menuItemCodon.Title);
                DisplayStyle = _menuItemCodon.DisplayStyle;
                if (_menuItemCodon.ShortcutKeys != Keys.None)
                {
                    ShortcutKeys = _menuItemCodon.ShortcutKeys;
                }
                if (String.IsNullOrEmpty(_menuItemCodon.IconResource) == false)
                {
                    ResourceService resources = ServiceManager.GetService<ResourceService>();
                    Image = resources.GetImage(_menuItemCodon.IconResource);
                }
                ConditionFailedAction action =
                    _menuItemCodon.GetConditionFailedAction(_caller);
                Visible = action != ConditionFailedAction.Exclude;
                Enabled = action != ConditionFailedAction.Disable; 
            }
            foreach (ToolStripItem item in DropDownItems)
            {
                IStatusEventReceiver receiver = item as IStatusEventReceiver;
                if (receiver != null)
                {
                    receiver.Update();
                }
            }
        }
    }
}

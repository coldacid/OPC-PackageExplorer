using System;
using System.Collections.Generic;

namespace PackageExplorer.ObjectModel
{
    public abstract class SelectableCollectionBase<TItem>
        : CollectionBase<TItem>
        where TItem : ItemBase, IActivatable
    {
        TItem _selectedItem = default(TItem);

        public TItem PrimarySelection
        {
            get { return _selectedItem; }
        }

        protected SelectableCollectionBase(object parent, bool isMultiSelect)
            : base(parent)
        {
        }

        public bool IsSelected(TItem item)
        {
            return item != default(TItem) && _selectedItem == item;
        }

        protected override void OnItemAdded(ItemEventArgs<TItem> e)
        {
            IActivatable item = (IActivatable)e.Item;            
            item.Activated += Item_Activated;
            item.Deactivated += Item_Deactivated;
            base.OnItemAdded(e);
        }

        protected override void OnItemRemoved(ItemEventArgs<TItem> e)
        {
            bool selectionChanged = false;
            TItem item = e.Item;
            if (IsSelected(item))
            {
                _selectedItem = default(TItem);
                selectionChanged = true;
            }
            item.Deactivated -= Item_Deactivated;
            item.Activated -= Item_Activated;
            base.OnItemRemoved(e);
            if (selectionChanged)
            {
                OnSelectionChanged(EventArgs.Empty);
            }
        }

        protected virtual void OnSelectionChanged(EventArgs e)
        {
            EventHandler<EventArgs> handler = SelectionChanged;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        void Item_Activated(object sender, EventArgs e)
        {
            SelectItem((TItem)sender, true);
        }

        void Item_Deactivated(object sender, EventArgs e)
        {
            UnselectItem((TItem)sender);
        }

        void SelectItem(TItem item)
        {
            SelectItem(item, false);
        }

        void SelectItem(TItem item, bool force)
        {
            if (_selectedItem != item || force == true)
            {
                _selectedItem = item;
                OnSelectionChanged(EventArgs.Empty);
            }
        }

        void UnselectItem(TItem item)
        {
            if (item == _selectedItem)
            {
                _selectedItem = default(TItem);
                OnSelectionChanged(EventArgs.Empty);
            }
        }

        public event EventHandler<EventArgs> SelectionChanged;
    }
}

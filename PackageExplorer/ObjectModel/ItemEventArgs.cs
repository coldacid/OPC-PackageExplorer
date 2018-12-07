using System;
using System.Collections.Generic;

namespace PackageExplorer.ObjectModel
{
    public class ItemEventArgs<TItem> 
        : EventArgs 
        where TItem : ItemBase
    {
        TItem _item = null;

        public TItem Item
        {
            get { return _item; }
        }

        public ItemEventArgs(TItem item)
        {
            _item = item;
        }
    }
}

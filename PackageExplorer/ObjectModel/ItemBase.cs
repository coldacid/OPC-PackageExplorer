using System;
using System.ComponentModel;

namespace PackageExplorer.ObjectModel
{
    public abstract class ItemBase 
        : INotifyPropertyChanged
    {
        object _parent = null;

        public object Parent
        {
            get { return _parent; }
        }

        protected ItemBase(object parent)
        {
            _parent = parent;
        }

        protected void RaisePropertyChanged(string propertyName)
        {
            OnPropertyChanged(new PropertyChangedEventArgs(propertyName));
            OnItemChanged(new ItemEventArgs<ItemBase>(this));
        }

        protected virtual void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        protected virtual void OnItemChanged(ItemEventArgs<ItemBase> e)
        {
            EventHandler<ItemEventArgs<ItemBase>> handler = ItemChanged;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public event EventHandler<ItemEventArgs<ItemBase>> ItemChanged;
    }
}

#region [===== Using =====]
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Collections.Specialized;
#endregion

namespace PackageExplorer.ObjectModel
{
    public abstract class CollectionBase<TItem>
        : IEnumerable<TItem>, INotifyCollectionChanged
        where TItem : ItemBase
    {
        #region [===== Instance fields =====]
        List<TItem> _items = null;
        WeakReference _parent = null;
        #endregion

        #region [===== Properties =====]
        public int Count
        {
            get { return _items.Count; }
        }

        public TItem this[int index]
        {
            get { return _items[index]; }
        }

        protected List<TItem> InnerList
        {
            get { return _items; }
        }

        #endregion

        #region [===== Constructors =====]
        protected CollectionBase(object parent)
        {
            _parent = new WeakReference(parent);
            _items = new List<TItem>();
        }
        #endregion

        #region [===== Public instance methods =====]
        public bool Contains(TItem item)
        {
            return _items.Contains(item);
        }

        public TItem Find(Predicate<TItem> predicate)
        {
            return _items.Find(predicate);
        }

        public virtual void Add(TItem item)
        {
            if (item != null)
            {
                _items.Add(item);
                item.ItemChanged += CollectionItem_Changed;
                OnItemAdded(new ItemEventArgs<TItem>(item));
                OnCollectionChanged(new NotifyCollectionChangedEventArgs(
                    NotifyCollectionChangedAction.Add, item));
            }
        }

        public virtual void Remove(TItem item)
        {
            if (_items.Contains(item))
            {
                item.ItemChanged -= CollectionItem_Changed;
                _items.Remove(item);
                OnItemRemoved(new ItemEventArgs<TItem>(item));
                OnCollectionChanged(new NotifyCollectionChangedEventArgs(
                    NotifyCollectionChangedAction.Remove, item));
            }
        }

        public IEnumerator<TItem> GetEnumerator()
        {
            return _items.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable<TItem>)this).GetEnumerator();
        }
        #endregion

        #region [===== Protected instance methods =====]
        protected virtual void OnItemRemoved(ItemEventArgs<TItem> e)
        {
            EventHandler<ItemEventArgs<TItem>> handler = ItemRemoved;
            if (handler != null)
            {
                handler(_parent.Target, e);
            }
        }

        protected virtual void OnItemAdded(ItemEventArgs<TItem> e)
        {
            EventHandler<ItemEventArgs<TItem>> handler = ItemAdded;
            if (handler != null)
            {
                handler(_parent.Target, e);
            }
        }

        protected virtual void OnCollectionItemChanged(ItemEventArgs<ItemBase> e)
        {
            EventHandler<ItemEventArgs<ItemBase>> handler = CollectionItemChanged;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        protected virtual void OnCollectionChanged(NotifyCollectionChangedEventArgs e)
        {
            NotifyCollectionChangedEventHandler handler = CollectionChanged;
            if (handler != null)
            {
                handler(this, e);
            }
        }
        #endregion

        #region [===== Private instance methods =====]
        void CollectionItem_Changed(object sender, ItemEventArgs<ItemBase> e)
        {           
            OnCollectionItemChanged(new ItemEventArgs<ItemBase>(e.Item));
        }
        #endregion

        #region [===== Events =====]
        public event EventHandler<ItemEventArgs<TItem>> ItemAdded;
        public event EventHandler<ItemEventArgs<TItem>> ItemRemoved;
        public event EventHandler<ItemEventArgs<ItemBase>> CollectionItemChanged;
        public event NotifyCollectionChangedEventHandler CollectionChanged;
        #endregion
    }
}

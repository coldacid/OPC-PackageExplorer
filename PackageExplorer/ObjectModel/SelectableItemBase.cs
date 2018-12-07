using System;
using System.ComponentModel;

namespace PackageExplorer.ObjectModel
{
    public abstract class SelectableItemBase
        : ItemBase, IActivatable
    {
        protected SelectableItemBase(object parent)
            : base(parent)
        {
        }

        public bool Activate()
        {
            bool activated = false;
            CancelEventArgs e = new CancelEventArgs();
            OnActivating(e);
            if (e.Cancel == false)
            {
                activated = true;
                OnActivated(EventArgs.Empty);
            }
            return activated;
        }

        public bool Deactivate()
        {
            bool deactivated = false;
            CancelEventArgs e = new CancelEventArgs();
            OnDeactivating(e);
            if (e.Cancel == false)
            {
                deactivated = true;
                OnDeactivated(EventArgs.Empty);
            }
            return deactivated;
        }

        protected virtual void OnActivating(CancelEventArgs e)
        {
            EventHandler<CancelEventArgs> handler = Activating;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        protected virtual void OnActivated(EventArgs e)
        {
            EventHandler<EventArgs> handler = Activated;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        protected virtual void OnDeactivating(CancelEventArgs e)
        {
            EventHandler<CancelEventArgs> handler = Deactivating;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        protected virtual void OnDeactivated(EventArgs e)
        {
            EventHandler<EventArgs> handler = Deactivated;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        public event EventHandler<CancelEventArgs> Activating;
        public event EventHandler<EventArgs> Activated;

        public event EventHandler<CancelEventArgs> Deactivating;
        public event EventHandler<EventArgs> Deactivated;
    }
}

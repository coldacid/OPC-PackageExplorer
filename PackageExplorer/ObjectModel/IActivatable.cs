using System;
using System.ComponentModel;

namespace PackageExplorer.ObjectModel
{
    public interface IActivatable
    {
        bool Activate();
        bool Deactivate();

        event EventHandler<CancelEventArgs> Activating;
        event EventHandler<EventArgs> Activated;

        event EventHandler<CancelEventArgs> Deactivating;
        event EventHandler<EventArgs> Deactivated;

    }
}

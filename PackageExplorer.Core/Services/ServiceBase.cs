#region [===== Using =====]
using System;
#endregion

namespace PackageExplorer.Core.Services
{
    /// <summary>
    /// A base class for IService implementations.
    /// </summary>
    public abstract class ServiceBase
        : IService
    {
        #region [===== Constructors =====]
        /// <summary>
        /// Initializes a new instance of the <see cref="ServiceBase"/> class.
        /// </summary>
        protected ServiceBase()
        {
        }
        #endregion

        #region [===== Public instance methods =====]
        /// <summary>
        /// Performs the operations required for initializing a service.
        /// </summary>
        public virtual void InitializeService()
        {
            if (Initialized != null)
            {
                Initialized(this, EventArgs.Empty);
            }
        }

        /// <summary>
        /// Performs the operations required for tearin down a service.
        /// </summary>
        public virtual void ShutdownService()
        {
            if (ShutDown != null)
            {
                ShutDown(this, EventArgs.Empty);
            }
        }
        #endregion

        #region [===== Events =====]
        public event EventHandler<EventArgs> Initialized;
        public event EventHandler<EventArgs> ShutDown;
        #endregion
    }
}

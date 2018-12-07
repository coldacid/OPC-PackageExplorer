#region [===== Using =====]
using System;
#endregion

namespace PackageExplorer.Core.Services
{
    /// <summary>
    /// Represents a service in the Package Explorer service model.
    /// </summary>
    public interface IService
    {
        #region [===== Instance methods =====]
        /// <summary>
        /// Performs the operations required for initializing a service.
        /// </summary>
        void InitializeService();
        /// <summary>
        /// Performs the operations required for tearing down a service.
        /// </summary>
        void ShutdownService();
        #endregion

        #region [===== Events =====]
        event EventHandler<EventArgs> Initialized;
        event EventHandler<EventArgs> ShutDown;
        #endregion
    }
}

#region [===== Using =====]
using System;
using System.ComponentModel.Design;
using System.Collections;
#endregion

namespace PackageExplorer.Core.Services
{
    /// <summary>
    /// A class for managing services.
    /// </summary>
    public class ServiceManager 
        : ServiceContainer
    {
        #region [===== Static fields =====]
        static ServiceManager _services = null;
        #endregion

        #region [===== Properties =====]
        /// <summary>
        /// Gets the service identified by <paramref name="serviceType"/>.
        /// </summary>
        /// <param name="serviceType">The <see cref="Type"/> of the 
        /// service to retrieve. This can be a class or interface type.</param>
        /// <returns>The service object, or null when the service was not found.</returns>
        public object this[Type serviceType]
        {
            get { return GetService(serviceType); }
        }

        /// <summary>
        /// Gets the default container for services.
        /// </summary>
        public static ServiceManager Services
        {
            get { return _services; }
        }
        #endregion

        #region [===== Constructors =====]
        static ServiceManager()
        {            
            _services = new ServiceManager();
            InitializeCoreServices(new IService[]{
                new StringParserService(),
                new ResourceService()});
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ServiceManager"/> class.
        /// </summary>
        public ServiceManager()
        {
        }
        #endregion

        #region [===== Public static methods =====]
        /// <summary>
        /// Gets the service identified by the generic type 
        /// parameter <typeparamref name="TService"/>.
        /// </summary>
        /// <typeparam name="TService">The type of service to retrieve.</typeparam>
        /// <returns>The service object, or null when the service was not found.</returns>
        public static TService GetService<TService>()
        {
            return (TService)Services.GetService(typeof(TService));
        }

        /// <summary>
        /// Registers and initializes a set of services based on their implementations
        /// of the <see cref="IService"/> interface, and their class type. 
        /// </summary>
        /// <param name="services">The list of services to initialize.</param>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="services"/>
        /// is null.</exception>
        public static void InitializeCoreServices(IEnumerable services)
        {
            if (services == null)
            {
                throw new ArgumentNullException("services");
            }
            Type serviceType = typeof(IService);
            foreach (object serviceObject in services)
            {
                ServiceManager.Services.AddService(serviceObject.GetType(), serviceObject);
                foreach (Type interfaceType in serviceObject.GetType().GetInterfaces())
                {
                    if (serviceType.IsAssignableFrom(interfaceType) &&
                        serviceType != interfaceType)
                    {
                        ServiceManager.Services.AddService(
                            interfaceType, serviceObject);
                    }
                }
                IService service = serviceObject as IService;
                if (service != null)
                {
                    service.InitializeService();
                }
            }
        }
        #endregion
    }
}

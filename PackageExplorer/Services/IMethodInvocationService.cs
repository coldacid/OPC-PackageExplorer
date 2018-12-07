using System;
using PackageExplorer.Core.Services;

namespace PackageExplorer.Services
{
    public interface IMethodInvocationService
        : IService
    {
        object Invoke(Delegate method, params object[] arguments);
    }
}

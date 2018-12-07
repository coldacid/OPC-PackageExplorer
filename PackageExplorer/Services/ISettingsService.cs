using System;
using System.Configuration;
using PackageExplorer.Core.Services;

namespace PackageExplorer.Services
{
    public interface ISettingsService
        : IService
    {
        TSettings GetSettings<TSettings>()
            where TSettings : ApplicationSettingsBase, new();
    }
}

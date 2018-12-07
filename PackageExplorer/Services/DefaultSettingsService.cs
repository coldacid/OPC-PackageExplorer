using System;
using System.Collections.Generic;
using System.Configuration;
using PackageExplorer.Core.Services;
using PackageExplorer.ObjectModel;

namespace PackageExplorer.Services
{
    class DefaultSettingsService
        : ServiceBase, ISettingsService
    {
        Dictionary<Type, ApplicationSettingsBase> _settings = null;

        public DefaultSettingsService()
        {
            _settings = new Dictionary<Type, ApplicationSettingsBase>();
            System.Windows.Forms.Application.ApplicationExit += 
                delegate(object sender, EventArgs e)
                {
                    foreach (ApplicationSettingsBase settings in _settings.Values)
                    {
                        settings.Save();
                    }
                };
        }

        public TSettings GetSettings<TSettings>() 
            where TSettings : ApplicationSettingsBase, new()
        {
            TSettings settings = null;
            Type settingsType = typeof(TSettings);
            if (_settings.ContainsKey(settingsType))
            {
                settings = (TSettings)_settings[settingsType];
            }
            else
            {
                settings = new TSettings();
                _settings.Add(settingsType, settings);
            }
            return settings;
        }
    }
}

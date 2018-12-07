using System;
using System.Globalization;
using System.Resources;

namespace PackageExplorer.UI.Language
{
    class LanguagePack
    {
        string _description = null;
        CultureInfo _language = null;

        public string Description
        {
            get { return _description; }
        }

        public CultureInfo Language
        {
            get { return _language; }
        }

        public LanguagePack(string description, string cultureName)
        {
            _description = description;
            _language = new CultureInfo(cultureName);
        }

        public LanguagePack(string description, CultureInfo culture)
        {
            _description = description;
            _language = culture;
        }
    }
}

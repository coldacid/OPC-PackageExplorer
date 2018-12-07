using System;
using PackageExplorer.Core.Services;
using System.Collections.Generic;
using PackageExplorer.Core.AddInModel;
using System.Globalization;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace PackageExplorer.UI.Language
{
    class LanguageService
        : ServiceBase
    {
        List<LanguagePack> _languagePacks = null;

        [DllImport("kernel32.dll")]
        static extern ushort GetUserDefaultUILanguage();

        public CultureInfo DefaultUICulture
        {
            get
            {
                return CultureInfo.InvariantCulture;
            }
        }

        //public CultureInfo ActiveCulture
        //{
        //    get
        //    {
        //    }
        //}

        public IEnumerable<LanguagePack> GetLanguagePacks()
        {
            if (_languagePacks == null)
            {
                _languagePacks = new List<LanguagePack>();
                IAddInTreeNode languagePacksNode =
                    AddInTreeSingleton.AddInTree.GetTreeNode("/workspace/languagePacks");
                if (languagePacksNode != null)
                {
                    foreach (LanguagePack languagePack in languagePacksNode.BuildChildItems(this))
                    {
                        _languagePacks.Add(languagePack);
                    }
                }
                ushort defaultUILanguage = GetUserDefaultUILanguage();
                CultureInfo defaultCulture = new CultureInfo(defaultUILanguage);
                _languagePacks.Add(new LanguagePack("Default Windows Setting", defaultCulture));
            }
            return _languagePacks;
        }

        protected virtual void OnActiveLanguageChanged(EventArgs e)
        {
            EventHandler handler = ActiveLanguageChanged;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        public event EventHandler ActiveLanguageChanged;
    }
}

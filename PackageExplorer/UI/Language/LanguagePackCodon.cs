using System;
using PackageExplorer.Core.AddInModel.Codons;
using PackageExplorer.Core.AddInModel;
using System.Collections;

namespace PackageExplorer.UI.Language
{
    [CodonName("LanguagePack")]
    [RequiredAttribute("cultureName")]
    [RequiredAttribute("description")]
    class LanguagePackCodon
        : CodonBase
    {
        string _cultureName;
        string _description;

        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }

        public string CultureName
        {
            get { return _cultureName; }
            set { _cultureName = value; }
        }

        public override object BuildItem(object owner, ArrayList subItems)
        {
            return new LanguagePack(_description, _cultureName);
        }
    }
}

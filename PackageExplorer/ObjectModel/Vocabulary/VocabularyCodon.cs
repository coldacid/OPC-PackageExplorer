using System;
using PackageExplorer.Core.AddInModel.Codons;
using PackageExplorer.Core.AddInModel;
using System.Collections;

namespace PackageExplorer.ObjectModel.Vocabulary
{
    [RequiredAttribute("filename")]
    [CodonName("Vocabulary")]
    class VocabularyCodon
        : CodonBase
    {
        public string Filename { get; set; }

        public override object BuildItem(object owner, ArrayList subItems)
        {
            return Filename;
        }
    }
}

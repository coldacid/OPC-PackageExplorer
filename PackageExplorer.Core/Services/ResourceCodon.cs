using System;
using PackageExplorer.Core.AddInModel.Codons;
using PackageExplorer.Core.AddInModel;

namespace PackageExplorer.Core.Services
{
    [RequiredAttribute("resourceGroup")]
    abstract class ResourceCodon
        : CodonBase
    {
        private string _resourceGroup;

        public string ResourceGroup
        {
            get { return _resourceGroup; }
            set { _resourceGroup = value; }
        }

    }
}

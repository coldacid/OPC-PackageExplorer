using System;
using System.Xml;

namespace PackageExplorer.Core.AddInModel.Codons
{
    public interface ICodonDeserialization
    {
        void Deserialize(XmlNode codonNode);
    }
}

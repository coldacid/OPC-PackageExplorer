using System;
using System.IO.Packaging;

namespace PackageExplorer.ObjectModel.Extension
{
    public static class PackageExtensions
    {
        public static PackageRelationship GetRelationshipByType(this Package package, string relationshipType)
        {
            PackageRelationship firstRelationship = null;
            foreach (PackageRelationship relationship in package.GetRelationshipsByType(relationshipType))
            {
                firstRelationship = relationship;
                break;
            }
            return firstRelationship;
        }
    }
}

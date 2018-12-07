using System;

namespace PackageExplorer.ObjectModel
{
    public class ExternalRelationship
        : ItemBase
    {
        Uri _targetUri;

        public Uri TargetUri
        {
            get { return _targetUri; }
        }

        internal ExternalRelationship(object owner, Uri targetUri)
            : base(owner)
        {
            _targetUri = targetUri;
        }
    }
}

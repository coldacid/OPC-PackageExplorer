using System;

namespace PackageExplorer.ObjectModel
{
    public class ExternalRelationshipEventArgs
        : EventArgs
    {
        ExternalRelationship _externalRelationship;
        
        public ExternalRelationship ExternalRelationship
        {
            get { return _externalRelationship; }
        }

        public ExternalRelationshipEventArgs(ExternalRelationship externalRelationship)
        {
            _externalRelationship = externalRelationship;
        }
    }
}

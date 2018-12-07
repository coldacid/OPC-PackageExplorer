using System;
using System.IO.Packaging;
using System.Collections.Generic;

namespace PackageExplorer.ObjectModel
{
    public class ExternalRelationshipCollection
        : IEnumerable<ExternalRelationship>
    {
        IRelatable _owner = null;
        Dictionary<PackageRelationship, ExternalRelationship> _relationships = null;

        public int Count
        {
            get { return _relationships.Count; }
        }

        internal ExternalRelationshipCollection(IRelatable owner)
        {
            _owner = owner;
            _relationships = new Dictionary<PackageRelationship, ExternalRelationship>();
        }

        public string GetRelationshipID(ExternalRelationship externalRelationship)
        {
            string relationshipID = null;
            PackageRelationship relationship = FindPackageRelationship(externalRelationship);
            if (relationship != null)
            {
                relationshipID = relationship.Id;
            }
            return relationshipID;
        }

        public ExternalRelationship Add(
            Uri targetUri, string relationshipType)
        {
            return Add(targetUri, relationshipType, null);
        }

        public ExternalRelationship Add(
            Uri targetUri, string relationshipType, string relationshipID)
        {
            PackageRelationship relationship = _owner.RelateTo(targetUri, relationshipType, relationshipID);
            ExternalRelationship externalRelationship =                
                new ExternalRelationship(this, targetUri);
            AddInternal(relationship, externalRelationship);

            return externalRelationship;
        }

        public void Remove(ExternalRelationship externalRelationship)
        {
            PackageRelationship relationship = FindPackageRelationship(externalRelationship);
            if (relationship != null)
            {
                _owner.RemoveRelationship(relationship.Id);
                _relationships.Remove(relationship);
                OnItemRemoved(new ExternalRelationshipEventArgs(externalRelationship));
            }
        }

        internal void AddInternal(PackageRelationship packageRelationship,
            ExternalRelationship relationship)
        {
            _relationships.Add(packageRelationship, relationship);
            OnItemAdded(new ExternalRelationshipEventArgs(relationship));
        }

        public IEnumerator<ExternalRelationship> GetEnumerator()
        {
            return _relationships.Values.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return ((IEnumerable<ExternalRelationship>)this).GetEnumerator();
        }

        protected virtual void OnItemAdded(ExternalRelationshipEventArgs e)
        {
            EventHandler<ExternalRelationshipEventArgs> handler = ItemAdded;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        protected virtual void OnItemRemoved(ExternalRelationshipEventArgs e)
        {
            EventHandler<ExternalRelationshipEventArgs> handler = ItemRemoved;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        PackageRelationship FindPackageRelationship(ExternalRelationship externalRelationship)
        {
            PackageRelationship packageRelationship = null;
            foreach (KeyValuePair<PackageRelationship, ExternalRelationship> relationship
                in _relationships)
            {
                if (relationship.Value == externalRelationship)
                {
                    packageRelationship = relationship.Key;
                    break;
                }
            }
            return packageRelationship;
        }

        public event EventHandler<ExternalRelationshipEventArgs> ItemAdded;
        public event EventHandler<ExternalRelationshipEventArgs> ItemRemoved;
    }
}

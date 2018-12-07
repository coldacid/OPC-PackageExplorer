namespace PackageExplorer.ObjectModel
{
    using System;
    using System.Collections.Generic;
    using System.IO.Packaging;
    using System.Linq;

    public class DocumentPartCollection
        : IEnumerable<DocumentPart>
    {
        IRelatable _owner;
        Document _document = null;
        Dictionary<PackageRelationship, DocumentPart> _parts = null;

        internal DocumentPartCollection(Document document, IRelatable owner)
        {
            _owner = owner;
            _document = document;
            _parts = new Dictionary<PackageRelationship, DocumentPart>();
        }

        public bool HasRelationship(string relationshipType)
        {
            return _parts.Keys.Where(
                pr => pr.RelationshipType == relationshipType).Count() > 0;
        }

        public bool HasRelationshipID(string relationshipID)
        {
            return _parts.Keys.Where(
                pr => pr.Id == relationshipID).Count() > 0;
        }

        public string GetRelationshipType(DocumentPart part)
        {
            string relationshipType = null;
            if (_parts.ContainsValue(part))
            {
                PackageRelationship relationship = GetRelationship(part);
                relationshipType = relationship.RelationshipType;
            }
            return relationshipType;
        }

        public string GetRelationshipID(DocumentPart part)
        {
            string relationshipID = null;
            if (_parts.ContainsValue(part))
            {
                PackageRelationship relationship = GetRelationship(part);
                relationshipID = relationship.Id;
            }
            return relationshipID;
        }

        public void Add(DocumentPart part,
            string relationshipType)
        {
            Add(part, relationshipType, null);
        }

        public void Add(DocumentPart part, string relationshipType, string relationshipID)
        {
            PackageRelationship relationship = GetRelationship(part);
            if (relationship == null)
            {
                relationship = _owner.RelateTo(
                    part, relationshipType, relationshipID);
                AddInternal(part, relationship);
                OnItemAdded(new DocumentPartEventArgs(part));
            }
        }

        public void Remove(DocumentPart part)
        {
            PackageRelationship relationship = GetRelationship(part);
            if (relationship != null)
            {
                _owner.RemoveRelationship(relationship.Id);
                part.RemoveParentRelationship(relationship);
                _parts.Remove(relationship);
                OnItemRemoved(new DocumentPartEventArgs(part));
            }
        }

        public bool Contains(DocumentPart part)
        {
            return _parts.ContainsValue(part);
        }

        public IEnumerator<DocumentPart> GetEnumerator()
        {
            return _parts.Values.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return ((IEnumerable<DocumentPart>)this).GetEnumerator();
        }

        internal void AddInternal(DocumentPart documentPart,
            PackageRelationship relationship)
        {
            _parts.Add(relationship, documentPart);
            documentPart.AddParentRelationship(relationship);
        }

        protected virtual void OnItemAdded(DocumentPartEventArgs e)
        {
            EventHandler<DocumentPartEventArgs> handler = ItemAdded;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        protected virtual void OnItemRemoved(DocumentPartEventArgs e)
        {
            EventHandler<DocumentPartEventArgs> handler = ItemRemoved;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        PackageRelationship GetRelationship(DocumentPart part)
        {
            foreach (PackageRelationship relationship in
                _parts.Keys)
            {
                if (_parts[relationship] == part)
                {
                    return relationship;
                }
            }
            return null;
        }

        public event EventHandler<DocumentPartEventArgs> ItemAdded;
        public event EventHandler<DocumentPartEventArgs> ItemRemoved;
    }
}

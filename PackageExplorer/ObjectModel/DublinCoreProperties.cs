using System;
using System.IO.Packaging;

namespace PackageExplorer.ObjectModel
{
    public class DublinCoreProperties
    {
        PackageProperties _packageProperties = null;

        public string Category
        {
            get { return _packageProperties.Category; }
            set
            {
                if (_packageProperties.Category != value)
                {
                    _packageProperties.Category = value;
                    OnPropertyChanged(EventArgs.Empty);
                }
            }
        }

        public string ContentStatus
        {
            get { return _packageProperties.ContentStatus; }
            set
            {
                if (_packageProperties.ContentStatus != value)
                {
                    _packageProperties.ContentStatus = value;
                    OnPropertyChanged(EventArgs.Empty);
                }
            }
        }

        public string ContentType
        {
            get { return _packageProperties.ContentType; }
            set
            {
                if (_packageProperties.ContentType != value)
                {
                    _packageProperties.ContentType = value;
                    OnPropertyChanged(EventArgs.Empty);
                }
            }
        }

        public DateTime? Created
        {
            get { return _packageProperties.Created; }
            set
            {
                if (_packageProperties.Created != value)
                {
                    _packageProperties.Created = value;
                    OnPropertyChanged(EventArgs.Empty);
                }
            }
        }

        public string Creator
        {
            get { return _packageProperties.Creator; }
            set
            {
                if (_packageProperties.Creator != value)
                {
                    _packageProperties.Creator = value;
                    OnPropertyChanged(EventArgs.Empty);
                }
            }
        }

        public string Description
        {
            get { return _packageProperties.Description; }
            set
            {
                if (_packageProperties.Description != value)
                {
                    _packageProperties.Description = value;
                    OnPropertyChanged(EventArgs.Empty);
                }
            }
        }

        public string Identifier
        {
            get { return _packageProperties.Identifier; }
            set
            {
                if (_packageProperties.Identifier != value)
                {
                    _packageProperties.Identifier = value;
                    OnPropertyChanged(EventArgs.Empty);
                }
            }
        }

        public string Keywords
        {
            get { return _packageProperties.Keywords; }
            set
            {
                if (_packageProperties.Keywords != value)
                {
                    _packageProperties.Keywords = value;
                    OnPropertyChanged(EventArgs.Empty);
                }
            }
        }

        public string Language
        {
            get { return _packageProperties.Language; }
            set
            {
                if (_packageProperties.Language != value)
                {
                    _packageProperties.Language = value;
                    OnPropertyChanged(EventArgs.Empty);
                }
            }
        }

        public string LastModifiedBy
        {
            get { return _packageProperties.LastModifiedBy; }
            set
            {
                if (_packageProperties.LastModifiedBy != value)
                {
                    _packageProperties.LastModifiedBy = value;
                    OnPropertyChanged(EventArgs.Empty);
                }
            }
        }

        public DateTime? LastPrinted
        {
            get { return _packageProperties.LastPrinted; }
            set
            {
                if (_packageProperties.LastPrinted != value)
                {
                    _packageProperties.LastPrinted = value;
                    OnPropertyChanged(EventArgs.Empty);
                }
            }
        }

        public DateTime? Modified
        {
            get { return _packageProperties.Modified; }
            set
            {
                if (_packageProperties.Modified != value)
                {
                    _packageProperties.Modified = value;
                    OnPropertyChanged(EventArgs.Empty);
                }
            }
        }

        public string Revision
        {
            get { return _packageProperties.Revision; }
            set
            {
                if (_packageProperties.Revision != value)
                {
                    _packageProperties.Revision = value;
                    OnPropertyChanged(EventArgs.Empty);
                }
            }
        }

        public string Subject
        {
            get { return _packageProperties.Subject; }
            set
            {
                if (_packageProperties.Subject != value)
                {
                    _packageProperties.Subject = value;
                    OnPropertyChanged(EventArgs.Empty);
                }
            }
        }

        public string Title
        {
            get { return _packageProperties.Title; }
            set
            {
                if (_packageProperties.Title != value)
                {
                    _packageProperties.Title = value;
                    OnPropertyChanged(EventArgs.Empty);
                }
            }
        }

        public string Version
        {
            get { return _packageProperties.Version; }
            set
            {
                if (_packageProperties.Version != value)
                {
                    _packageProperties.Version = value;
                    OnPropertyChanged(EventArgs.Empty);
                }
            }
        }

        internal DublinCoreProperties(PackageProperties packageProperties)
        {
            _packageProperties = packageProperties;
        }

        public override string ToString()
        {
            return String.Empty;
        }

        protected virtual void OnPropertyChanged(EventArgs e)
        {
            EventHandler<EventArgs> handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        public event EventHandler<EventArgs> PropertyChanged;
    }
}

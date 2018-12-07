using System;
using System.IO;
using PackageExplorer.Utils;

namespace PackageExplorer.UI.Workbench
{
    class FileContentSource
        : IContentSource
    {
        string _path = null;

        public string Path
        {
            get { return _path; }
        }

        public ContentTypes ContentType
        {
            get
            {
                return ContentTypeMappings.GetContentTypeForExtension(
                    System.IO.Path.GetExtension(_path));
            }
        }

        public string Title
        {
            get { return System.IO.Path.GetFileName(_path); }
        }

        public FileContentSource(string path)
        {
            _path = path;
        }

        public bool HasSameSourceAs(IContentSource other)
        {
            bool hasSameSource = false;
            FileContentSource source = other as FileContentSource;
            if (source != null)
            {
                hasSameSource = source.Path == _path;
            }
            return hasSameSource;
        }

        public Stream GetContent()
        {
            return new FileStream(_path, FileMode.Open, FileAccess.Read);
        }

        public void SetContent(byte[] content)
        {
            File.WriteAllBytes(_path, content);
        }
    }
}

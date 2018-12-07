using System;
using System.IO;
using PackageExplorer.Utils;

namespace PackageExplorer.UI.Workbench
{
    public interface IContentSource
    {
        ContentTypes ContentType { get;}
        string Title { get;}
        bool HasSameSourceAs(IContentSource other);
        Stream GetContent();
        void SetContent(byte[] content);
    }
}

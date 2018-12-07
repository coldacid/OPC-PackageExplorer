using System;
using PackageExplorer.Core.Services;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace PackageExplorer.Services
{
    public interface IRecentDocumentService
        : IService, IEnumerable
    {
        int Count { get;}
        string this[int index] { get;}
        void OpenRecentDocument(string path);
        void Clear();
    }
}

using System;
using PackageExplorer.Core.Services;
using PackageExplorer.ObjectModel;
using PackageExplorer.ObjectModel.Vocabulary;
using System.Collections.Generic;

namespace PackageExplorer.Services
{
    public interface IVocabularyService
        : IService
    {
        IEnumerable<PackageVocabulary> Vocabularies { get; }
        PackageVocabulary GetVocabularyByContentType(string contentType);
    }
}

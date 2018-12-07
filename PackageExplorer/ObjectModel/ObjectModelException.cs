using System;
using PackageExplorer.Core;

namespace PackageExplorer.ObjectModel
{
    [global::System.Serializable]
    public class ObjectModelException : PackageExplorerException
    {
        public ObjectModelException() { }
        public ObjectModelException(string message) : base(message) { }
        public ObjectModelException(string message, Exception inner) : base(message, inner) { }
        protected ObjectModelException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context)
            : base(info, context) { }
    }
}

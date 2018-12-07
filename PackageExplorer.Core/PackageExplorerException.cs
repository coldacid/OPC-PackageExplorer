using System;

namespace PackageExplorer.Core
{
    [global::System.Serializable]
    public class PackageExplorerException : ApplicationException
    {
        public PackageExplorerException() { }
        public PackageExplorerException(string message) : base(message) { }
        public PackageExplorerException(string message, Exception inner) : base(message, inner) { }
        protected PackageExplorerException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context)
            : base(info, context) { }
    }
}

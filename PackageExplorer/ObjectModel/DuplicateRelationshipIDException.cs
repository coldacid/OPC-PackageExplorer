using System;

namespace PackageExplorer.ObjectModel
{
    [global::System.Serializable]
    public class DuplicateRelationshipIDException : ObjectModelException
    {
        //
        // For guidelines regarding the creation of new exception types, see
        //    http://msdn.microsoft.com/library/default.asp?url=/library/en-us/cpgenref/html/cpconerrorraisinghandlingguidelines.asp
        // and
        //    http://msdn.microsoft.com/library/default.asp?url=/library/en-us/dncscol/html/csharp07192001.asp
        //

        public DuplicateRelationshipIDException() { }
        public DuplicateRelationshipIDException(string message) : base(message) { }
        public DuplicateRelationshipIDException(string message, Exception inner) : base(message, inner) { }
        protected DuplicateRelationshipIDException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context)
            : base(info, context) { }
    }
}

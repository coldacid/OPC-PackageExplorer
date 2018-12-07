namespace PackageExplorer.Core.AddInModel
{	
	using System;
	using System.Runtime.Serialization;

	/// <summary>
	/// Represents the error which is thrown when an element of the addin 
	/// tree XML definition is missing required attributes.
	/// </summary>
	[Serializable]
	public class MissingAttributeException : AddInTreeException
	{
		#region [===== Constructors =====]
		/// <summary>
		/// Initializes a new instance of the <see cref="MissingAttributeException"/> 
		/// class. This is the default constructor.
		/// </summary>
		public MissingAttributeException()
		{}

		/// <summary>
		/// Initializes a new instance of the <see cref="MissingAttributeException"/> 
		/// class with the specified message.
		/// </summary>
		public MissingAttributeException(string message): base(message)
		{}

		/// <summary>
		/// Initializes a new instance of the <see cref="MissingAttributeException"/> 
		/// class with the specified string and inner exception.
		/// </summary>
		public MissingAttributeException(string message, Exception innerException) : base(message, innerException)
		{}

		/// <summary>
		/// Initializes a new instance of the <see cref="MissingAttributeException"/> 
		/// class with the specified serialization information and context.
		/// </summary>
		public MissingAttributeException(SerializationInfo info, StreamingContext context) : base(info, context)
		{}
		#endregion
	}
}

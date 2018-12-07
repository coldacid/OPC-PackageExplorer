namespace PackageExplorer.Core.AddInModel
{
	#region [===== Using =====]
	using System;
	using System.Runtime.Serialization;
	#endregion

	/// <summary>
	/// Represents the base exception for errors thrown by the AddInTree.
	/// </summary>
	[Serializable]
    public class AddInTreeException : PackageExplorerException
	{
		#region [===== Constructors =====]
		/// <summary>
		/// Initializes a new instance of the <see cref="AddInTreeException"/> 
		/// class. This is the default constructor.
		/// </summary>
		public AddInTreeException()
		{}

		/// <summary>
		/// Initializes a new instance of the <see cref="AddInTreeException"/> 
		/// class with the specified message.
		/// </summary>
		public AddInTreeException(string message): base(message)
		{}

		/// <summary>
		/// Initializes a new instance of the <see cref="AddInTreeException"/> 
		/// class with the specified string and inner exception.
		/// </summary>
		public AddInTreeException(string message, Exception innerException) : base(message, innerException)
		{}

		/// <summary>
		/// Initializes a new instance of the <see cref="AddInTreeException"/> 
		/// class with the specified serialization information and context.
		/// </summary>
		public AddInTreeException(SerializationInfo info, StreamingContext context) : base(info, context)
		{}
		#endregion
	}
}

namespace PackageExplorer.Core.AddInModel
{
	#region [===== Using =====]
	using System;
	using System.Runtime.Serialization;
	#endregion

	/// <summary>
	/// Represents the exception which is thrown when an AddIn fails to
	/// load correctly.
	/// </summary>
	[Serializable]
	public class AddInLoadException : AddInTreeException
	{
		#region [===== Constructors =====]
		/// <summary>
		/// Initializes a new instance of the <see cref="AddInLoadException"/> 
		/// class. This is the default constructor.
		/// </summary>
		public AddInLoadException()
		{}

		/// <summary>
		/// Initializes a new instance of the <see cref="AddInLoadException"/> 
		/// class with the specified message.
		/// </summary>
		public AddInLoadException(string message): base(message)
		{}

		/// <summary>
		/// Initializes a new instance of the <see cref="AddInLoadException"/> 
		/// class with the specified string and inner exception.
		/// </summary>
		public AddInLoadException(string message, Exception innerException) : base(message, innerException)
		{}

		/// <summary>
		/// Initializes a new instance of the <see cref="AddInLoadException"/> 
		/// class with the specified serialization information and context.
		/// </summary>
		public AddInLoadException(SerializationInfo info, StreamingContext context) : base(info, context)
		{}
		#endregion
	}
}

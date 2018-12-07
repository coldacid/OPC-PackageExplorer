namespace PackageExplorer.Core.AddInModel
{
	#region [===== Using =====]
	using System;
	using System.Runtime.Serialization;
	#endregion

	/// <summary>
	/// Represents the exception which is thrown when a format error occurs in
	/// the addin XML file.
	/// </summary>
	[Serializable]
	public class AddInFormatException : AddInTreeException
	{
		#region [===== Constructors =====]
		/// <summary>
		/// Initializes a new instance of the <see cref="AddInFormatException"/> 
		/// class. This is the default constructor.
		/// </summary>
		public AddInFormatException()
		{}

		/// <summary>
		/// Initializes a new instance of the <see cref="AddInFormatException"/> 
		/// class with the specified message.
		/// </summary>
		public AddInFormatException(string message): base(message)
		{}

		/// <summary>
		/// Initializes a new instance of the <see cref="AddInFormatException"/> 
		/// class with the specified string and inner exception.
		/// </summary>
		public AddInFormatException(string message, Exception innerException) : base(message, innerException)
		{}

		/// <summary>
		/// Initializes a new instance of the <see cref="AddInFormatException"/> 
		/// class with the specified serialization information and context.
		/// </summary>
		public AddInFormatException(SerializationInfo info, StreamingContext context) : base(info, context)
		{}
		#endregion
	}
}

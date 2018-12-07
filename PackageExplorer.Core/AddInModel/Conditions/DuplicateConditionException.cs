namespace PackageExplorer.Core.AddInModel.Conditions
{
	#region [===== Using =====]
	using System;
	using System.Runtime.Serialization;
	#endregion

	/// <summary>
	/// Represents the error which is thrown when a <see cref="ConditionBuilder"/> for a
	/// specific condition class is already present in the <see cref="ConditionFactory"/>.
	/// </summary>
	[Serializable]
	public class DuplicateConditionException : AddInTreeException
	{
		#region [===== Constructors =====]
		/// <summary>
		/// Initializes a new instance of the <see cref="DuplicateConditionException"/> 
		/// class. This is the default constructor.
		/// </summary>
		public DuplicateConditionException()
		{}

		/// <summary>
		/// Initializes a new instance of the <see cref="DuplicateConditionException"/> 
		/// class with the specified message.
		/// </summary>
		public DuplicateConditionException(string message): base(message)
		{}

		/// <summary>
		/// Initializes a new instance of the <see cref="DuplicateConditionException"/> 
		/// class with the specified string and inner exception.
		/// </summary>
		public DuplicateConditionException(string message, Exception innerException) : base(message, innerException)
		{}

		/// <summary>
		/// Initializes a new instance of the <see cref="DuplicateConditionException"/> 
		/// class with the specified serialization information and context.
		/// </summary>
		public DuplicateConditionException(SerializationInfo info, StreamingContext context) : base(info, context)
		{}
		#endregion
	}
}

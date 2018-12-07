namespace PackageExplorer.Core.AddInModel.Conditions
{
	#region [===== Using =====]
	using System;
	using System.Runtime.Serialization;
	#endregion

	/// <summary>
	/// Represents the error which is thrown when a condition class isn't 
	/// found by the <see cref="ConditionFactory"/>.
	/// </summary>
	[Serializable]
	public class ConditionNotFoundException : AddInTreeException
	{
		#region [===== Constructors =====]
		/// <summary>
		/// Initializes a new instance of the <see cref="ConditionNotFoundException"/> 
		/// class. This is the default constructor.
		/// </summary>
		public ConditionNotFoundException()
		{}

		/// <summary>
		/// Initializes a new instance of the <see cref="ConditionNotFoundException"/> 
		/// class with the specified message.
		/// </summary>
		public ConditionNotFoundException(string message): base(message)
		{}

		/// <summary>
		/// Initializes a new instance of the <see cref="ConditionNotFoundException"/> 
		/// class with the specified string and inner exception.
		/// </summary>
		public ConditionNotFoundException(string message, Exception innerException) : base(message, innerException)
		{}

		/// <summary>
		/// Initializes a new instance of the <see cref="ConditionNotFoundException"/> 
		/// class with the specified serialization information and context.
		/// </summary>
		public ConditionNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
		{}
		#endregion
	}
}

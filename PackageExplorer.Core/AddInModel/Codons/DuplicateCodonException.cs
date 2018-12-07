namespace PackageExplorer.Core.AddInModel.Codons
{
	#region [===== Using =====]
	using System;
	using System.Runtime.Serialization;
	#endregion

	/// <summary>
	/// Represents the error which is thrown when a <see cref="CodonBuilder"/> for a
	/// specific codon class is already present in the <see cref="CodonFactory"/>.
	/// </summary>
	[Serializable]
	public class DuplicateCodonException : AddInTreeException
	{
		#region [===== Constructors =====]
		/// <summary>
		/// Initializes a new instance of the <see cref="DuplicateCodonException"/> 
		/// class. This is the default constructor.
		/// </summary>
		public DuplicateCodonException()
		{}

		/// <summary>
		/// Initializes a new instance of the <see cref="DuplicateCodonException"/> 
		/// class with the specified message.
		/// </summary>
		public DuplicateCodonException(string message): base(message)
		{}

		/// <summary>
		/// Initializes a new instance of the <see cref="DuplicateCodonException"/> 
		/// class with the specified string and inner exception.
		/// </summary>
		public DuplicateCodonException(string message, Exception innerException) : base(message, innerException)
		{}

		/// <summary>
		/// Initializes a new instance of the <see cref="DuplicateCodonException"/> 
		/// class with the specified serialization information and context.
		/// </summary>
		public DuplicateCodonException(SerializationInfo info, StreamingContext context) : base(info, context)
		{}
		#endregion
	}
}


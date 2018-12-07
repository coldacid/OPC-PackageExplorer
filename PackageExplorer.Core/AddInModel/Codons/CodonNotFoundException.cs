namespace PackageExplorer.Core.AddInModel.Codons
{
	#region [===== Using =====]
	using System;
	using System.Runtime.Serialization;
	#endregion

	/// <summary>
	/// Represents the error which is thrown when a codon class isn't found by the <see cref="CodonFactory"/>.
	/// </summary>
	[Serializable]
	public class CodonNotFoundException : AddInTreeException
	{
		#region [===== Constructors =====]
		/// <summary>
		/// Initializes a new instance of the <see cref="CodonNotFoundException"/> 
		/// class. This is the default constructor.
		/// </summary>
		public CodonNotFoundException()
		{}

		/// <summary>
		/// Initializes a new instance of the <see cref="CodonNotFoundException"/> 
		/// class with the specified message.
		/// </summary>
		public CodonNotFoundException(string message): base(message)
		{}

		/// <summary>
		/// Initializes a new instance of the <see cref="CodonNotFoundException"/> 
		/// class with the specified string and inner exception.
		/// </summary>
		public CodonNotFoundException(string message, Exception innerException) : base(message, innerException)
		{}

		/// <summary>
		/// Initializes a new instance of the <see cref="CodonNotFoundException"/> 
		/// class with the specified serialization information and context.
		/// </summary>
		public CodonNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
		{}
		#endregion
	}	
}

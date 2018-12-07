namespace PackageExplorer.Core.AddInModel.Codons
{
	#region [===== Using =====]
	using System;
	#endregion

	/// <summary>
	/// This attribute placed on a <see cref="ICodon"/> class, and is used to name 
	/// the codon.
	/// </summary>
	[AttributeUsage( AttributeTargets.Class, Inherited = false, AllowMultiple=false)]
	public class CodonNameAttribute : Attribute
	{
		#region [===== Instance fields =====]
		/// <summary>
		/// The name of the codon.
		/// </summary>
		string _codonName;
		#endregion

		#region [===== Properties =====]
		/// <summary>
		/// Gets the name of the codon.
		/// </summary>
		public string Name
		{
			get{ return _codonName;}
		}
		#endregion

		#region [===== Constructors =====]
		/// <summary>
		/// Initializes a new instance of the <see cref="CodonNameAttribute"/>
		/// class.
		/// </summary>
		/// <param name="name">The name of the codon.</param>
		public CodonNameAttribute(string name)
		{
			_codonName = name;
		}
		#endregion
	}
}

namespace PackageExplorer.Core.AddInModel
{
	#region [===== Using =====]
	using System;
	#endregion

	/// <summary>
	/// This attribute is placed on classes which derive from <see cref="ICodon"/>, 
	/// providing information about an attribute which the codon expects.
	/// </summary>
	[AttributeUsage( AttributeTargets.Class, Inherited = false, AllowMultiple=true)]
	public class RequiredAttributeAttribute : Attribute
	{
		#region [===== Instance fields =====]
		/// <summary>
		/// The name of the attribute which is required by a codon.
		/// </summary>
		string _attributeName;
		#endregion

		#region [===== Properties =====]
		/// <summary>
		/// Gets the name of the attribute which is required by a codon.
		/// </summary>
		public string AttributeName
		{
			get{ return _attributeName;}
		}
		#endregion

		#region [===== Constructors =====]
		/// <summary>
		/// Initializes a new instance of the <see cref="RequiredAttributeAttribute"/> class.
		/// </summary>
		/// <param name="attributeName">The name of the attribute which is 
		/// required by a codon.</param>
		public RequiredAttributeAttribute(string attributeName)
		{
			_attributeName = attributeName;
		}
		#endregion
	}
}

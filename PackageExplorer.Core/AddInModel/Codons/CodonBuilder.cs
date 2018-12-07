namespace PackageExplorer.Core.AddInModel.Codons
{
	#region [===== Using =====]
	using System;
	using System.Reflection;
	#endregion

	/// <summary>
	/// The <see cref="CodonBuilder"/> is able to build the codon object representation
	/// from a specific assembly.
	/// </summary>
	public class CodonBuilder
	{
		#region [===== Instance fields =====]
		/// <summary>
		/// The <see cref="Assembly"/> in which the <see cref="ICodon"/> is defined.
		/// </summary>
		Assembly _assembly;
		/// <summary>
		/// The classname of the <see cref="ICodon"/>.
		/// </summary>
		string _className;
		#endregion

		#region [===== Properties =====]
		/// <summary>
		/// The name of the codon which this <see cref="CodonBuilder"/> can build, 
		/// the name is derived using the <see cref="CodonNameAttribute"/> which should
		/// be defined on the codon class.
		/// </summary>
		public string CodonName
		{
			get
			{ 
				CodonNameAttribute codonName = (CodonNameAttribute)Attribute.GetCustomAttribute(
					_assembly.GetType(_className), typeof(CodonNameAttribute));
				return codonName.Name;
			}
		}
		#endregion

		#region [===== Constructors =====]
		/// <summary>
		/// Initializes a new instance of the <see cref="CodonBuilder"/> class.
		/// </summary>
		/// <param name="className">The classname of the <see cref="ICodon"/> which 
		/// this <see cref="CodonBuilder"/> will build.</param>
		/// <param name="assembly">The <see cref="Assembly"/> which contains the
		/// codon class.</param>
		public CodonBuilder(string className, Assembly assembly)
		{
			_className = className;
			_assembly = assembly;
		}
		#endregion

		#region [===== Public instance methods =====]
		/// <summary>
		/// Build the codon which this <see cref="CodonBuilder"/> contains.
		/// </summary>
		/// <param name="addIn">The <see cref="AddIn"/> which defined the 
		/// codon XML node.</param>
		/// <returns>The <see cref="ICodon"/> which this <see cref="CodonBuilder"/>
		/// describes.</returns>
		public ICodon BuildCodon(AddIn addIn)
		{
			try
			{
				ICodon codon = (ICodon)_assembly.CreateInstance(_className, true);
				codon.AddIn = addIn;
				return codon;
			}
			catch(Exception ex)
			{
				string msg = String.Format("Codon {0} not found in assembly {1}.", 
					_className, _assembly.GetName().Name);
				throw new CodonNotFoundException(msg, ex);
			}			
		}
		#endregion
	}
}

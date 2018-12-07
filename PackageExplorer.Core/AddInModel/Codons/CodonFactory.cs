namespace PackageExplorer.Core.AddInModel.Codons
{
	#region [===== Using =====]
	using System;
    using System.Collections.Generic;
	#endregion

	/// <summary>
	/// The <see cref="CodonFactory"/> creates <see cref="ICodon"/> objects using their
	/// <see cref="CodonBuilder.CodonName"/> property. 
	/// </summary>
	public class CodonFactory
	{
		#region [===== Instance fields =====]
		/// <summary>
		/// The container for <see cref="CodonBuilder"/> objects, stored using
		/// the codon <see cref="ICodon.Name"/>.
		/// </summary>
        Dictionary<String, CodonBuilder> _codonBuilders =
            new Dictionary<string, CodonBuilder>();
		#endregion

		#region [===== Public instance methods =====]
		/// <summary>
		/// Add a new <see cref="CodonBuilder"/> to the <see cref="CodonFactory"/>, enabling
		/// the factory to create codons using a specific <see cref="ICodon.Name"/>.
		/// </summary>
		/// <param name="builder">The <see cref="CodonBuilder"/> to add to the factory.</param>
		/// <exception cref="DuplicateCodonException">Thrown when a <see cref="CodonBuilder"/> for
		/// the codon already exists.</exception>
		public void AddCodonBuilder(CodonBuilder builder)
		{
			if(_codonBuilders.ContainsKey(builder.CodonName))
			{			
				throw new DuplicateCodonException(String.Format("Codon {0} already exists.",
					builder.CodonName));
			}
			_codonBuilders.Add(builder.CodonName, builder);
		}

		/// <summary>
		/// Creates an <see cref="ICodon"/> object using a specific codon name.
		/// </summary>
		/// <param name="addIn">The <see cref="AddIn"/> which defines the codon
		/// XML node.</param>
		/// <param name="codonName">The name of the XML node, corresponding with the
		/// <see cref="ICodon.Name"/> of the codon.</param>
		/// <returns>The codon referenced by <paramref name="codonName"/>.</returns>
		/// <exception cref="CodonNotFoundException">Thrown when a <see cref="CodonBuilder"/> for
		/// <paramref name="codonName"/> isn't found.</exception>
		public ICodon CreateCodon(AddIn addIn, string codonName)
		{
			if(_codonBuilders.ContainsKey(codonName) == false)
			{
				throw new CodonNotFoundException(String.Format("Codon {0} not found.",
					codonName));
			}
			return _codonBuilders[codonName].BuildCodon(addIn);
		}
		#endregion
	}
}

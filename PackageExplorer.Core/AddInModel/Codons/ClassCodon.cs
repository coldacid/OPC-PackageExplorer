namespace PackageExplorer.Core.AddInModel.Codons
{
	#region [===== Using =====]
	using System;
	using System.Collections.Generic;
	using PackageExplorer.Core.AddInModel.Conditions;
    using System.Collections;
	#endregion

	/// <summary>
	/// A <see cref="ICodon"/> which creates a specific class. 
	/// </summary>
	/// <remarks>
	/// This codon requires the 'class' attribute in the codon XML node. The class
	/// specified should take the form '&lt;namespace&gt;&lt;classname&gt;'.
	/// </remarks>
	[CodonName("Class")]
	[RequiredAttribute("class")]
	public class ClassCodon : CodonBase
	{
		#region [===== Instance fields =====]
		/// <summary>
		/// The name of the class which the codon will create.
		/// </summary>
		string _class = null;
		#endregion

        public string Class
        {
            get { return _class; }
            set { _class = value; }
        }

		#region [===== Public instance methods =====]
	    public override object BuildItem(object owner, ArrayList subItems)
		{
			return AddIn.CreateObject(_class);
		}
		#endregion
	}
}

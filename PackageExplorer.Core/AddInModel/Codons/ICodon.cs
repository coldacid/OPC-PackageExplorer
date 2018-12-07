namespace PackageExplorer.Core.AddInModel.Codons
{
	#region [===== Using =====]
	using System;
	using System.Collections;
	using System.Collections.Generic;
	using System.Xml;
	using PackageExplorer.Core.AddInModel.Conditions;
    using System.ComponentModel;
	#endregion

	/// <summary>
	/// Defines the object representation of an XML extension node in the 
	/// addin definition. A codon describes some kind of object and is able to 
	/// instantiate the object it describes using the attributes defined in the 
	/// codon XML node.
	/// </summary>
	public interface ICodon
	{
		#region [===== Properties =====]
		/// <summary>
		/// Gets the name of the <see cref="ICodon"/>, which corresponds with the name
		/// of the codon XML node.
		/// </summary>
		string CodonName{ get;}

		/// <summary>
		/// Gets a unique identifier for the <see cref="ICodon"/>, used to uniquely identify
		/// the codon amongst it's sibbling codons in the addin tree. 
		/// </summary>
        string ID { get; set;}

		/// <summary>
		/// Gets or sets the <see cref="AddIn"/> which defined the codon.
		/// </summary>
		AddIn AddIn{ get; set;}

        List<ICondition> Conditions { get; set;}
        bool HandlesConditions { get;}
        bool HandlesDeserialization { get;}
		/// <summary>
		/// Gets an array of <see cref="ICodon.ID"/> strings which this codon should be 
		/// inserted in front of.
		/// </summary>
        string[] InsertBefore { get; set;}

		/// <summary>
		/// Gets an array of <see cref="ICodon.ID"/> strings which this codon
		/// should be inserted after.
		/// </summary>
        [TypeConverter(typeof(PackageExplorer.Core.AddInModel.Codons.CodonBase.StringSplitConverter))]
        string[] InsertAfter { get; set;}
		#endregion

		#region [===== Public instance methods =====]
		/// <summary>
		/// Initialize the codon using the attributes defined in the codon XML node.
		/// </summary>
		/// <param name="attributes">The attributes defined in the codon XML node.</param>
		void Initialize();

		/// <summary>
		/// Build the object which this codon describes.
		/// </summary>
		/// <param name="owner">The owner of the object created by the codon.</param>
		/// <param name="subItems">An array of objects which are the subitems of the codon.</param>
		/// <param name="conditions">The conditions which can be used to determine the 
		/// state of the codon, making it possible to hide or disable it.</param>
		/// <returns>The object which corresponds with this codon, initialized using the parameters
		/// passed into the codon using the <see cref="ICodon.Initialize"/> method.</returns>
		object BuildItem(object owner, ArrayList subItems);
		#endregion

        ConditionFailedAction GetConditionFailedAction(object owner);
    }
}

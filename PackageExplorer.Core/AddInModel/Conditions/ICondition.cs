#region [===== Using =====]
using System;
using System.Xml;
using System.Collections.Generic;
#endregion

namespace PackageExplorer.Core.AddInModel.Conditions
{
	/// <summary>
	/// Defines the structure for a condition which can contain child
	/// conditions.
	/// </summary>
	public interface ICondition
	{
		#region [===== Properties =====]
		/// <summary>
		/// Gets or sets the action which should be taken when the condition fails.
		/// </summary>
		ConditionFailedAction Action{ get; set;}
		/// <summary>
		/// Gets the conditions which are defined as children of this condition.
		/// </summary>
        IEnumerable<ICondition> ChildConditions { get;}
		#endregion

		#region [===== Public instance methods =====]
		/// <summary>
		/// Append a new child condition to this condition.
		/// </summary>
		/// <param name="condition">The child to add.</param>
		void AppendChild(ICondition condition);

		/// <summary>
		/// Returns a value indicating whether the condition is valid.
		/// </summary>
		/// <param name="caller">The object which is interested in the 
		/// validity of the condition.</param>
		/// <returns><b>True</b> when the condition is currently valid,
		/// otherwise <b>False</b>.</returns>
		bool IsValid(object caller);
		#endregion
	}
}

namespace PackageExplorer.Core.AddInModel.Conditions
{
	#region [===== Using =====]
	using System;
	using System.Collections.Generic;
	#endregion

	/// <summary>
	/// The <see cref="ConditionFactory"/> creates <see cref="ICondition"/> objects
	/// using their <see cref="ConditionBuilder.ConditionName"/> property.
	/// </summary>
	public class ConditionFactory
	{
		#region [===== Instance fields =====]
		/// <summary>
		/// The container for <see cref="ConditionBuilder"/> objects, stored using
		/// the codon <see cref="ConditionBuilder.ConditionName"/>.
		/// </summary>
        Dictionary<String, ConditionBuilder> _conditionBuilders = 
            new Dictionary<String, ConditionBuilder>();
		#endregion

		#region [===== Public instance methods =====]
		/// <summary>
		/// Add a new <see cref="ConditionBuilder"/> to the <see cref="ConditionFactory"/>, enabling
		/// the factory to create codons using a specific name.
		/// </summary>
		/// <param name="builder">The <see cref="ConditionBuilder"/> to add to the factory.</param>
		/// <exception cref="DuplicateConditionException">Thrown when a <see cref="ConditionBuilder"/> for
		/// the condition already exists.</exception>
		public void AddConditionBuilder(ConditionBuilder builder)
		{
			if(_conditionBuilders.ContainsKey(builder.ConditionName))
			{
				throw new DuplicateConditionException(builder.ConditionName);
			}
			_conditionBuilders.Add(builder.ConditionName, builder);
		}

		/// <summary>
		/// Creates an <see cref="ICondition"/> object using a specific condition name.
		/// </summary>
		/// <param name="conditionName">The name of the XML node, corresponding with the name
		/// of the condition.
		/// <returns>The condition referenced by <paramref name="conditionName"/>.</returns>
		/// <exception cref="ConditionNotFoundException">Thrown when a <see cref="ConditionBuilder"/> for
		/// <paramref name="conditionName"/> isn't found.</exception>
		public ICondition BuildCondition(string conditionName)
		{
			if (_conditionBuilders.ContainsKey(conditionName) == false)
			{
				throw new ConditionNotFoundException(conditionName);
			}
			return _conditionBuilders[conditionName].BuildCondition();
		}
		#endregion
	}
}

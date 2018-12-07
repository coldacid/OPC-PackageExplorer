namespace PackageExplorer.Core.AddInModel.Conditions
{
	#region [===== Using =====]
	using System;
	using System.Reflection;
	#endregion

	/// <summary>
	/// The <see cref="ConditionBuilder"/> is able to build the condition object representation
	/// from a specific assembly.
	/// </summary>
	public class ConditionBuilder
	{
		#region [===== Instance fields =====]
		/// <summary>
		/// The <see cref="Assembly"/> which defines the <see cref="ICondition"/>
		/// </summary>
		Assembly	_assembly;
		/// <summary>
		/// The classname of the <see cref="ICondition"/>.
		/// </summary>
		string		_className;
		#endregion

		#region [===== Properties =====]
		/// <summary>
		/// Gets the name of the condition, which corresponds with the name 
		/// of the XML node representation.
		/// </summary>
		public string ConditionName
		{
			get
			{ 
				ConditionNameAttribute conditionName = (ConditionNameAttribute)Attribute.GetCustomAttribute(
					_assembly.GetType(_className), typeof(ConditionNameAttribute));
				return conditionName.Name;
			}
		}
		#endregion

		#region [===== Constructors =====]
		/// <summary>
		/// Initializes a new instance of the <see cref="ConditionBuilder"/> class.
		/// </summary>
		/// <param name="conditionClass">The classname of the condition.</param>
		/// <param name="assembly">The assembly which contains the condition class.</param>
		public ConditionBuilder(string conditionClass, Assembly assembly)
		{
			_assembly = assembly;
			_className = conditionClass;
		}
		#endregion

		#region [===== Public instance fields =====]
		/// <summary>
		/// Build the condition which this <see cref="ConditionBuilder"/> contains.
		/// </summary>
		/// <returns>The <see cref="ICondition"/> which this <see cref="ConditionBuilder"/>
		/// describes.</returns>
		public ICondition BuildCondition()
		{
			try
			{
				ICondition condition = (ICondition)_assembly.CreateInstance(_className, true);
				return condition;
			}
			catch(Exception ex)
			{
				string msg = String.Format("Condition {0} not found in assembly {1}.", 
					_className, _assembly.GetName().Name);
				throw new ConditionNotFoundException(msg, ex);
			}			
		}
		#endregion
	}
}

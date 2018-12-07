namespace PackageExplorer.Core.AddInModel.Conditions
{
	#region [===== Using =====]
	using System;
	#endregion

	/// <summary>
	/// This attribute placed on a <see cref="ICondition"/> class, and is used to name 
	/// the condition.
	/// </summary>
	[AttributeUsage( AttributeTargets.Class, Inherited = false, AllowMultiple=false)]
	public class ConditionNameAttribute : Attribute
	{
		#region [===== Instance fields =====]
		/// <summary>
		/// The name of the condition.
		/// </summary>
		string _conditionName;
		#endregion

		#region [===== Properties =====]
		/// <summary>
		/// Gets the name of the condition.
		/// </summary>
		public string Name
		{
			get{ return _conditionName;}
		}
		#endregion

		#region [===== Constructors =====]
		/// <summary>
		/// Initializes a new instance of the <see cref="ConditionNameAttribute"/> class.
		/// </summary>
		/// <param name="name">The name of the condition.</param>
		public ConditionNameAttribute(string name)
		{
			_conditionName = name;
		}
		#endregion
	}
}


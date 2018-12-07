namespace PackageExplorer.Core.AddInModel.Conditions
{
	#region [===== Using =====]
	using System;
	using System.Diagnostics;
	using System.Xml;
	#endregion

	/// <summary>
	/// A condition which negates its child condition.
	/// </summary>
	/// <remarks>
	/// This condition only accepts one child condition.
	/// </remarks>
	[ConditionName("Not")]
	public class NegatedCondition : ConditionBase
	{
		#region [===== Public instance methods =====]
		public override bool IsValid(object caller)
		{
			Debug.Assert(_conditions.Count == 1);
			return !_conditions[0].IsValid(caller);
		}
		#endregion
	}

	/// <summary>
	/// A condition which returns true when all its child conditions 
	/// return true.
	/// </summary>
	/// <remarks>
	/// This condition only accepts more than one child condition.
	/// </remarks>
	[ConditionName("And")]
	public class AndCondition : ConditionBase
	{
		#region [===== Public instance methods =====]
		public override bool IsValid(object caller)
		{
			Debug.Assert(_conditions.Count > 1);
			bool valid = true;

			foreach(ICondition condition in _conditions)
			{
				valid &= condition.IsValid(caller);
			}
			return valid;
		}
		#endregion
	}

	/// <summary>
	/// A condition which returns true when one of its child conditions 
	/// return true.
	/// </summary>
	/// <remarks>
	/// This condition only accepts more than one child condition.
	/// </remarks>
	[ConditionName("Or")]
	public class OrCondition : ConditionBase
	{
		#region [===== Public instance methods =====]
		public override bool IsValid(object caller)
		{
			Debug.Assert(_conditions.Count > 1);
			bool valid = false;

			foreach(ICondition condition in _conditions)
			{
				valid |= condition.IsValid(caller);
			}
			return valid;
		}
		#endregion
	}

	/// <summary>
	/// A condition which returns true when a specific path exists in the tree.
	/// </summary>
	/// <remarks>
	/// This condition doesn't accept child conditions.
	/// </remarks>
	[RequiredAttribute("path")]
	[ConditionName("RequiredPath")]
	public class RequiredPathCondition : ConditionBase
	{
        #region [===== Instance fields =====]
        private string _path;
		#endregion

        public string Path
        {
            get { return _path; }
            set { _path = value; }
        }

		#region [===== Public instance methods =====]
		public override bool IsValid(object caller)
		{
			Debug.Assert(_conditions.Count  == 0);
			try
			{
                return AddInTreeSingleton.AddInTree.GetTreeNode(_path) != null;
			}
			catch(TreePathException)
			{
				return false;
			}
			catch(Exception ex)
			{
				throw ex;
			}
		}
		#endregion
	}
}

namespace PackageExplorer.Core.AddInModel.Conditions
{
	#region [===== Using =====]
	using System;
	using System.Collections.Generic;
	using System.Xml;
	#endregion
	
	/// <summary>
	/// An abstract implementation of the <see cref="ICondition"/> interface, 
	/// providing storage for child conditions.
	/// </summary>
    public abstract class ConditionBase : ICondition
    {
        #region [===== Instance fields =====]
        /// <summary>
        /// The action which should be taken when the condition fails.
        /// </summary>
        ConditionFailedAction _action = ConditionFailedAction.Nothing;
        /// <summary>
        /// A container for storing child conditions.
        /// </summary>
        protected List<ICondition> _conditions;
        #endregion

        #region [===== Properties =====]
        public IEnumerable<ICondition> ChildConditions
        {
            get { return _conditions; }
        }

        public ConditionFailedAction Action
        {
            get { return _action; }
            set { _action = value; }
        }
        #endregion

        #region [===== Constructor =====]
         public ConditionBase()
        {
            _conditions = new List<ICondition>();
        }
        #endregion

        #region [===== Public instance methods =====]
        public void AppendChild(ICondition condition)
        {
            _conditions.Add(condition);
        }

        public abstract bool IsValid(object caller);
        #endregion
    }
}

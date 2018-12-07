using System;
using System.Collections.Generic;
using System.Text;
using PackageExplorer.Core.AddInModel.Codons;

namespace PackageExplorer.Core.AddInModel.Conditions
{
	public static class Condition
	{
		public static ConditionFailedAction GetConditionFailedAction(
			List<ICondition> conditions, object caller)
		{
            ConditionFailedAction action = ConditionFailedAction.Nothing;
            if (conditions != null && conditions.Count > 0)
            {
                for (int i = conditions.Count - 1; i >= 0; i--)
                {
                    ICondition condition = conditions[i];
                    if (condition.IsValid(caller) == false)
                    {
                        if(condition.Action == ConditionFailedAction.Exclude)
                        {
                            action = condition.Action;
                            break;
                        }
                        else if(condition.Action == ConditionFailedAction.Disable)
                        {
                            action= condition.Action;
                        }
                    }
                }            
            }
            return action;
		}
	}
}

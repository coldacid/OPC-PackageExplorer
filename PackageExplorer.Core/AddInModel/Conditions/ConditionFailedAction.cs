using System;

namespace PackageExplorer.Core.AddInModel.Conditions
{
    /// <summary>
    /// Specifies what action to take in the codon, when 
    /// the condition for the codon failes.
    /// </summary>
    public enum ConditionFailedAction
    {
        /// <summary>
        /// Do nothing.
        /// </summary>
        Nothing,
        /// <summary>
        /// Exclude the codon (default)
        /// </summary>
        Exclude,
        /// <summary>
        /// Disable the codon.
        /// </summary>
        Disable
    }
}

namespace PackageExplorer.Core.AddInModel.Codons
{
	#region [===== Using =====]
	using System;
	#endregion

	/// <summary>
	/// Represents a command which can be executed.
	/// </summary>
	public interface ICommand
	{
        string Name { get;}

		#region [===== Public instance methods =====]
		/// <summary>
		/// Executes the command.
		/// </summary>
		void Execute();
		#endregion
	}
}

namespace PackageExplorer.Core.AddInModel
{
	#region [===== Using =====]
	using System;
	using System.Collections.Specialized;
	using System.IO;
	using System.Reflection;
	using PackageExplorer.Core.AddInModel.Conditions;
	using PackageExplorer.Core.AddInModel.Codons;
    using System.Text;
	#endregion

	/// <summary>
	/// Provides one method for accessing the AddInTree, via the singleton accessor.
	/// The initialization of the AddInTree also occurs from this class.
	/// </summary>
	public static class AddInTreeSingleton
	{
		#region [===== Static fields =====]
		/// <summary>
		/// The file mask used for searching addins.
		/// </summary>
        static readonly string _addInFileMask = "*.addin";

        /// <summary>
        /// The actual AddInTree.
        /// </summary>
        static IAddInTree _addInTree = new DefaultAddInTree();
		#endregion

		#region [===== Properties =====]
		/// <summary>
		/// Gets the addin tree.
		/// </summary>
		public static IAddInTree AddInTree
		{
            get { return _addInTree; }
		}
		#endregion

        public static void LoadAddInDirectory(string path)
        {
            StringCollection addInFiles = new StringCollection();
            StringCollection retryList = new StringCollection();
            addInFiles.AddRange(Directory.GetFiles(path, _addInFileMask));
            retryList = InsertAddIns(addInFiles);
            while (retryList.Count > 0)
            {
                StringCollection newRetryList = InsertAddIns(retryList);

                // break if no add-in could be inserted.
                if (newRetryList.Count == retryList.Count)
                {
                    break;
                }
                retryList = newRetryList;
            }
            if (retryList.Count > 0)
            {
                StringBuilder error = new StringBuilder();
                error.AppendLine("Failed to load the following addins due to missing definitions.");
                foreach (string retryItem in retryList)
                {
                    error.AppendLine(retryItem);
                }
                throw new PackageExplorerException(error.ToString());
            }
        }

		#region [===== Private static methods =====]
		static StringCollection InsertAddIns(StringCollection addInFiles)
		{
			StringCollection retryList  = new StringCollection();
			
			foreach (string addInFile in addInFiles) 
			{		
				try 
				{
					AddIn addIn = AddIn.CreateAddIn(addInFile);
					_addInTree.InsertAddIn(addIn);
				} 
				catch (CodonNotFoundException) 
				{
					retryList.Add(addInFile);
				} 
				catch (ConditionNotFoundException)
                {
					retryList.Add(addInFile);
				} 
				catch (Exception e)
                {
					throw new AddInLoadException(addInFile, e);
				} 
			}			
			return retryList;
		}
		#endregion
	}
}

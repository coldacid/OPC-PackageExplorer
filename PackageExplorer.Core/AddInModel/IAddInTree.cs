namespace PackageExplorer.Core.AddInModel
{
	using System;
	using System.Collections;
	using System.IO;
	using System.Reflection;	
	using PackageExplorer.Core.AddInModel.Codons;
	using PackageExplorer.Core.AddInModel.Conditions;
    using System.Collections.Generic;

	public interface IAddInTree
	{
		IAddInTreeNode Root{ get;}
		CodonFactory CodonFactory{ get;}
		ConditionFactory ConditionFactory{ get;}
		Assembly[] RuntimeLibraries{ get;}
		IEnumerable<AddIn> AddIns { get;}
        IAddInTreeNode this[string path] { get;}
        IAddInTreeNode GetTreeNode(string path);
        IAddInTreeNode GetTreeNode(string path, bool createMissing);
		Assembly LoadRuntimeLibrary(string assemblyPath);
		void InsertAddIn(AddIn addIn);
	}
}

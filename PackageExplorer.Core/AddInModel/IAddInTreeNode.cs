namespace PackageExplorer.Core.AddInModel
{
	using System;
	using System.Collections;
	using System.Collections.Generic;
	using PackageExplorer.Core.AddInModel.Codons;
	using PackageExplorer.Core.AddInModel.Conditions;

	public interface IAddInTreeNode
	{
		Extension Extension { get; set;}
		ICodon Codon{ get; set;}
		List<ICondition> Conditions{ get;}
        string Path { get;}
        string NodeName { get;}
        int Count { get;}
        IEnumerable<IAddInTreeNode> ChildNodes { get;}
        IAddInTreeNode this[string nodeName] { get;}

        bool HasChildNode(string nodeName);
        void Add(string nodeName, IAddInTreeNode node);
		object BuildItem(object caller);
		ArrayList BuildChildItems(object caller);
		object BuildChildItem(object caller, string childID);
	}
}
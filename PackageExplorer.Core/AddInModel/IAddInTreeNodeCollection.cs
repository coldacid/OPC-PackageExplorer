namespace PackageExplorer.Core.AddInModel
{
	using System;
	using System.Collections;

	public class IAddInTreeNodeCollection : IEnumerable
	{
		Hashtable _nodes = new Hashtable();

		public IAddInTreeNode this[string id]
		{
			get
			{
				return (IAddInTreeNode)_nodes[id];
			}
		}

		public int Count
		{
			get{ return _nodes.Values.Count;}
		}

		public IAddInTreeNodeCollection()
		{
		}

		IAddInTreeNodeEnumerator GetEnumerator()
		{
			return (IAddInTreeNodeEnumerator)((IEnumerable)this).GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return new IAddInTreeNodeEnumerator(this);
		}

		public class IAddInTreeNodeEnumerator : IEnumerator
		{
			IAddInTreeNodeCollection _enumerable = null;
			string[] _keys = null;

			public IAddInTreeNodeEnumerator(IAddInTreeNodeCollection enumerable)
			{
				_enumerable = enumerable;
				_keys = new string[enumerable.Count];
			}

			public void Reset()
			{
				
			}

			public IAddInTreeNode Current
			{
				get
				{
					return (IAddInTreeNode)((IEnumerator)this).Current;
				}
			}

			object IEnumerator.Current
			{
				get
				{
					return null;
					//return _enumerable[_currentKeyIndex];
				}
			}

			public bool MoveNext()
			{
				return false;
			}
		}
	}
}

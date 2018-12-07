namespace PackageExplorer.AddIns.AddInScout
{
	using System;
	using System.Collections;
	using System.Collections.Generic;
	using System.ComponentModel;
	using System.Drawing;
	using System.Data;
	using System.Text;
	using System.Windows.Forms;
    using PackageExplorer.Core.AddInModel;
    using PackageExplorer.Core.AddInModel.Codons;
    using PackageExplorer.Core.AddInModel.Conditions;

	public partial class ExtensionDetailsPanel : UserControl
	{
		int _activeGroupColumn = -1;
		int _groupColumnPriorWidth = 0;
		int _currentGroupColumn = -1;	// pls keep at -1;
		Hashtable[] _groupTables = null;
		
		public ICodon SelectedItem
		{
			get
			{
				if (_extensionDetailsView.SelectedItems.Count > 0)
				{
					return _extensionDetailsView.SelectedItems[0].Tag
						as ICodon;
				}
				return null;
			}
		}

		public ExtensionDetailsPanel()
		{
			InitializeComponent();
			_extensionDetailsView.ColumnClick += new ColumnClickEventHandler(_extensionDetailsView_ColumnClick);
		}

		public void SelectExtension(string path, IEnumerable<ICodon> extensions)
		{
			_extensionDetailsView.Items.Clear();
            foreach (ICodon codon in extensions)
			{
				ListViewItem item = new ListViewItem(new string[]{
							codon.CodonName, codon.ID, ""});
				item.Tag = codon;
				_extensionDetailsView.Items.Add(item);
			}
			CreateGroupTables();
            _extensionField.Text = path;
		}

		protected override void OnCreateControl()
		{
			ColumnHeader codonHeader = new ColumnHeader();
			codonHeader.Text = "Codon";
			codonHeader.Width = 100;
			ColumnHeader codonIDHeader = new ColumnHeader();
			codonIDHeader.Text = "Codon ID";
			codonIDHeader.Width = 100;
			ColumnHeader classHeader = new ColumnHeader();
			classHeader.Text = "Class";
			classHeader.Width = 100;

			_extensionDetailsView.Columns.AddRange(new ColumnHeader[]{
			    codonHeader, codonIDHeader, classHeader});
			
			base.OnCreateControl();
		}
		
		void _extensionDetailsView_ColumnClick(object sender, ColumnClickEventArgs e)
		{

			if (_extensionDetailsView.Sorting == SortOrder.Descending || (e.Column != _activeGroupColumn))
			{
				_extensionDetailsView.Sorting = SortOrder.Ascending;
			}
			else
			{
				_extensionDetailsView.Sorting = SortOrder.Descending;
			}
			_activeGroupColumn = e.Column;

			SetGroups(_activeGroupColumn);

		}

		void CreateGroupTables()
		{
			_groupTables = new Hashtable[_extensionDetailsView.Columns.Count];
			for (int i = 0; i < _groupTables.Length; i++)
			{
				_groupTables[i] = CreateGroupTable(i);
			}
		}

		void SetGroups(int columnIndex)
		{
			if (_currentGroupColumn != -1)
			{
				_extensionDetailsView.Columns[_currentGroupColumn].Width = _groupColumnPriorWidth;
			}
			_extensionDetailsView.Groups.Clear();

			Hashtable groups = _groupTables[columnIndex];
			ListViewGroup[] groupsArray = new ListViewGroup[groups.Count];
			groups.Values.CopyTo(groupsArray, 0);
			Array.Sort(groupsArray, new ListViewGroupSorter(_extensionDetailsView.Sorting));
			_extensionDetailsView.Groups.AddRange(groupsArray);

			foreach (ListViewItem item in _extensionDetailsView.Items)
			{
				// Retrieve the subitem text corresponding to the column.
				string subItemText = item.SubItems[columnIndex].Text;

				// Assign the item to the matching group.
				item.Group = (ListViewGroup)groups[subItemText];
			}
			_groupColumnPriorWidth = _extensionDetailsView.Columns[columnIndex].Width;
			_extensionDetailsView.Columns[columnIndex].Width = 0;
			_currentGroupColumn = columnIndex;
		}

		Hashtable CreateGroupTable(int columnIndex)
		{
			Hashtable groups = new Hashtable();
			foreach (ListViewItem item in _extensionDetailsView.Items)
			{
				string subItemText = item.SubItems[columnIndex].Text;

				if (!groups.Contains(subItemText))
				{
					string groupText = _extensionDetailsView.Columns[columnIndex].Text +
						": " + subItemText;
					groups.Add(subItemText, new ListViewGroup(groupText,
						HorizontalAlignment.Left));
				}
			}
			return groups;
		}

		class ListViewGroupSorter : IComparer
		{
			private SortOrder _order;

			// Stores the sort order.
			public ListViewGroupSorter(SortOrder order)
			{
				_order = order;
			}

			// Compares the groups by header value, using the saved sort
			// order to return the correct value.
			public int Compare(object x, object y)
			{
				int result = String.Compare(
					((ListViewGroup)x).Header,
					((ListViewGroup)y).Header
				);
				if (_order == SortOrder.Ascending)
				{
					return result;
				}
				else
				{
					return -result;
				}
			}
		}

		public event EventHandler SelectedIndexChanged
		{
			add
			{
				_extensionDetailsView.SelectedIndexChanged += value;
			}
			remove
			{
				_extensionDetailsView.SelectedIndexChanged -= value;
			}
		}
	}
}

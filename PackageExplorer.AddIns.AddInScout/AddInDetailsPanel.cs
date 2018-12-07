using System;
using System.ComponentModel;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;
using PackageExplorer.Core.AddInModel;

namespace PackageExplorer.AddIns.AddInScout
{
	public partial class AddInDetailsPanel : UserControl
	{
		public AddInDetailsPanel()
		{
			InitializeComponent();
			_detailsList.SelectedIndexChanged += new EventHandler(DetailsList_SelectedIndexChanged);
		}

		public void SelectObject(AddIn value)
		{
			_rightTextHeader.Text = value.Name;
			_detailsList.Items.Clear();
			foreach (PropertyInfo property in value.GetType().GetProperties())
			{
				if (property.PropertyType.IsArray == false &&
					property.PropertyType.IsGenericType == false)
				{
					object propertyValue = property.GetValue(value, null);
					TypeConverter converter = TypeDescriptor.GetConverter(propertyValue);
					if (converter is ExpandableObjectConverter)
					{
						ExpandableObjectConverter expandableConverter = converter as ExpandableObjectConverter;

					}else
					{
					
						ParseProperty(property, propertyValue, converter);
					}
				}
			}
		}

		private void ParseProperty(PropertyInfo property, object propertyValue, TypeConverter converter)
		{
			BrowsableAttribute browsable = Attribute.GetCustomAttribute(property, typeof(BrowsableAttribute))
				as BrowsableAttribute;
			if (converter.CanConvertTo(typeof(String)) &&(browsable == null ||
				browsable.Browsable == true))
			{
				string propertyValueString = converter.ConvertToString(propertyValue);
				ListViewItem item = new ListViewItem(new string[]{
							property.Name, propertyValueString});
				item.ToolTipText = propertyValueString;
				if (IsValidUri(propertyValueString))
				{
					SetUriFont(item);
				}
				DescriptionAttribute attribute = (DescriptionAttribute)Attribute.GetCustomAttribute(property, typeof(DescriptionAttribute));
				if (attribute != null)
				{
					item.Tag = attribute.Description;
				}
				_detailsList.Items.Add(item);
			}
		}


		bool IsValidUri(string value)
		{
			bool retVal = false;
			try
			{
				Uri uri = new Uri(value);
				retVal = true;
			}
			catch { }
			return retVal;
		}

		void SetUriFont(ListViewItem item)
		{
			item.Font = new Font(item.Font, FontStyle.Underline);
			item.ForeColor = Color.Blue;
		}

		void DetailsList_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (_detailsList.SelectedItems.Count > 0)
			{
				string propertyName = _detailsList.SelectedItems[0].Text;
				string description = "";
				if (_detailsList.SelectedItems.Count > 0 && _detailsList.SelectedItems[0].Tag != null)
				{
					description = _detailsList.SelectedItems[0].Tag.ToString();
				}
				_propertyNameField.Text = propertyName;
				_propertyDescriptionField.Text = description;
			}
		}

        private void AddInDetailsPanel_Load(object sender, EventArgs e)
        {

        }
	}
}

namespace PackageExplorer.Core.AddInModel.Codons
{
	#region [===== Using =====]
	using System;
	using System.Collections;
	using System.Collections.Generic;
	using System.Xml;
	using PackageExplorer.Core.AddInModel.Conditions;
using System.ComponentModel;
	#endregion

	/// <summary>
	/// An abstract implementation of the <see cref="ICodon"/> interface, 
	/// which initializes default attributes of each codon. 
	/// </summary>
	/// <remarks>
	/// The following attributes are initialized by the <see cref="AbstractCodon"/>
	/// <list type="bullet">
	///		<item><see cref="ICodon.ID"/></item>
	///		<item><see cref="ICodon.InsertBefore"/></item>
	///		<item><see cref="ICodon.InsertAfter"/></item>
	///		<item><see cref="ICodon.AddIn"/></item>
	/// </list>
	/// The <see cref="AbstractCodon"/> class requires the 'id' attribute to be
	/// present in the codon XML node.
	/// </remarks>
	[RequiredAttribute("id")]
	public abstract class CodonBase : ICodon
	{
		#region [===== Instance fields =====]
		string		_id;
		AddIn		_addIn;
		string[]	_insertBefore;
		string[]	_insertAfter;
        List<ICondition> _conditions;
		#endregion

		#region [===== Properties =====]
		public string ID
		{
			get{ return _id;}
            set { _id = value; }
		}

		public string CodonName
		{
			get
			{
				// The AddInTree won't load codons without the CodonNameAttribute defined,
				// we can access it to get the codon name (name of the XML node).
				CodonNameAttribute codonName = (CodonNameAttribute)Attribute.GetCustomAttribute(
					GetType(), typeof(CodonNameAttribute));
				return codonName.Name;
			}
		}

        public virtual bool HandlesDeserialization
        {
            get { return false; }
        }

        public List<ICondition> Conditions
        {
            get { return _conditions; }
            set { _conditions = value; }
        }

        [TypeConverter(typeof(PackageExplorer.Core.AddInModel.Codons.CodonBase.StringSplitConverter))]
		public string[] InsertBefore
		{
			get{ return _insertBefore;}
            set { _insertBefore = value; }
		}

        [TypeConverter(typeof(PackageExplorer.Core.AddInModel.Codons.CodonBase.StringSplitConverter))]
        public string[] InsertAfter
		{
			get{ return _insertAfter; }
            set { _insertAfter = value; }
		}

		public AddIn AddIn
		{
			get{ return _addIn;}
			set{ _addIn = value;}
		}

		public virtual bool HandlesConditions
		{
			get{ return false;}
		}
		#endregion

		#region [===== Public instance methods =====]
        public ConditionFailedAction GetConditionFailedAction(object owner)
        {
            ConditionFailedAction action = ConditionFailedAction.Nothing;
            if (_conditions != null)
            {
                action = Condition.GetConditionFailedAction(_conditions, owner);
            }
            return action;
        }
		public virtual void Initialize()
		{
		}

		public abstract object BuildItem(object owner, ArrayList subItems);
		#endregion

        public class StringSplitConverter : TypeConverter
        {
            public override bool CanConvertFrom(ITypeDescriptorContext context,
                Type sourceType)
            {
                if (sourceType == typeof(string))
                {
                    return true;
                }
                return base.CanConvertFrom(context, sourceType);
            }

            public override object ConvertFrom(ITypeDescriptorContext context,
                System.Globalization.CultureInfo culture, object value)
            {
                string stringValue = value as string;
                if (stringValue != null)
                {
                    return stringValue.Split('/');
                }
                return base.ConvertFrom(context, culture, value);
            }
        }
	}
}

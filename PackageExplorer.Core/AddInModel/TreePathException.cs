namespace PackageExplorer.Core.AddInModel
{
	#region [===== Using =====]
	using System;
	using System.Runtime.Serialization;
	using System.ComponentModel;
	#endregion

	/// <summary>
	/// Represents the error which is thrown when an error regarding 
	/// tree paths occurs.
	/// </summary>
	/// <remarks>An example of an error which could occur is requesting 
	/// a unknown path in the AddInTree.</remarks>
	[Serializable]
	public class TreePathException : AddInTreeException
	{
		string _errorPath;

		#region [===== Constructors =====]
		/// <summary>
		/// Initializes a new instance of the <see cref="TreePathException"/> 
		/// class. This is the default constructor.
		/// </summary>
		public TreePathException()
		{}

		/// <summary>
		/// Initializes a new instance of the <see cref="TreePathException"/> 
		/// class with the specified tree path which caused the error.
		/// </summary>
		/// <param name="errorPath">The path in the tree where the error occured.</param>
        public TreePathException(string errorPath)
			: this(errorPath, null, null)
		{
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="TreePathException"/> 
		/// class with the specified tree path which caused the error and the 
		/// specified message.
		/// </summary>
		/// <param name="errorPath">The path in the tree where the error occured.</param>
        public TreePathException(string errorPath, string message)
			: this(errorPath, message, null)
		{
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="TreePathException"/> 
		/// class with the specified tree path which caused the error and the 
		/// specified message and inner exception.
		/// </summary>
        public TreePathException(string errorPath, string message, Exception innerException)
			: base(message, innerException)
		{
			_errorPath = errorPath;
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="TreePathException"/> 
		/// class with the specified serialization information and context.
		/// </summary>
		protected TreePathException(SerializationInfo info, StreamingContext context) : base(info, context)
		{
            _errorPath = (string)info.GetValue("ErrorPath", typeof(string));
		}
		#endregion

		#region [===== Public instance methods =====]
		public override void GetObjectData(SerializationInfo info, StreamingContext context)
		{
            info.AddValue("ErrorPath", _errorPath, typeof(string));
			base.GetObjectData (info, context);
		}
		#endregion
	}
}

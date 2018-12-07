using System;
using System.Windows.Forms;
using System.IO;

namespace PackageExplorer.UI.Controls
{
    public class PackagePathTextBox
        : TextBox
    {
        ErrorProvider _errorProvider = null;
        bool _allowFolders = false;

        public ErrorProvider ErrorProvider
        {
            get { return _errorProvider; }
            set { _errorProvider = value; }
        }

        public bool AllowFolders
        {
            get { return _allowFolders; }
            set { _allowFolders = value; }
        }

        protected override void OnValidating(System.ComponentModel.CancelEventArgs e)
        {
            if (_errorProvider != null)
            {
                string path = Text;
                path = path.Trim();
                string error = null;
                if (String.IsNullOrEmpty(path))
                {
                    error = "Please enter a path for the item.";
                }
                else if (path.Length > 1 && path[1] == Path.VolumeSeparatorChar)
                {
                    error = "The path needs be be inside the package.";
                }
                else
                {
                    try
                    {
                        if (Path.GetFileName(path) == String.Empty)
                        {
                            error = "The path does not contain a filename.";
                        }
                        if (_allowFolders != (Path.GetDirectoryName(path) != String.Empty))
                        {
                            error = String.Format("A folder name is {0}",
                                _allowFolders ? "required" : "not allowed");
                        }
                    }
                    catch(ArgumentException)
                    {
                        error = "The path contains illegal characters.";
                    }
                }
                if (error != null)
                {
                    _errorProvider.SetError(this, error);
                    e.Cancel = true;
                }
            }
            base.OnValidating(e);
        }

        protected override void OnValidated(EventArgs e)
        {
            if (_errorProvider != null)
            {
                _errorProvider.SetError(this, String.Empty);
            }
            base.OnValidated(e);
        }
    }
}

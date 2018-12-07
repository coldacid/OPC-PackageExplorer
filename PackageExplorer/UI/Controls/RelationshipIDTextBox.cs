using System;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace PackageExplorer.UI.Controls
{
    public class RelationshipIDTextBox
        : TextBox
    {
        ErrorProvider _errorProvider;

        public ErrorProvider ErrorProvider
        {
            get { return _errorProvider; }
            set { _errorProvider = value; }
        }

        protected override void OnValidating(System.ComponentModel.CancelEventArgs e)
        {
            if (_errorProvider != null)
            {
                string error = null;
                if (String.IsNullOrEmpty(Text) == false)
                {
                    string pattern = "[a-zA-Z][a-zA-Z0-9]*";
                    if (Regex.IsMatch(Text, pattern) == false)
                    {
                        error = "A relationship ID needs to start with a letter and may contain digits.";
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

using System;
using System.Windows.Forms;

namespace PackageExplorer.UI.Controls
{
    public class RelationshipTypeTextBox
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
                Uri uri;
                if (String.IsNullOrEmpty(Text) ||
                    Uri.TryCreate(Text, UriKind.RelativeOrAbsolute, out uri) == false)
                {
                    _errorProvider.SetError(this, "The relationship type needs to be a valid URI");
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

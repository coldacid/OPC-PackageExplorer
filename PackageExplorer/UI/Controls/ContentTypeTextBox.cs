using System;
using System.ComponentModel;
using System.Net.Mime;
using System.Windows.Forms;

namespace PackageExplorer.UI.Controls
{
    public class ContentTypeTextBox
        : TextBox
    {
        ErrorProvider _errorProvider;

        public ErrorProvider ErrorProvider
        {
            get { return _errorProvider; }
            set { _errorProvider = value; }
        }

        protected override void OnValidating(CancelEventArgs e)
        {
            if (_errorProvider != null)
            {
                string error = null;
                if (String.IsNullOrEmpty(Text))
                {
                    error = "Please enter a content type.";
                }
                else
                {
                    try
                    {
                        ContentType contentType = new ContentType(Text);
                    }
                    catch (FormatException ex)
                    {
                        error = "The content type is invalid. " + ex.Message;
                    }
                }
                if (error != null)
                {
                    e.Cancel = true;
                    _errorProvider.SetError(this, error);
                }
            }
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

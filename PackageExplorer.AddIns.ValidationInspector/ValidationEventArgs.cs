namespace PackageExplorer.AddIns.ValidationInspector
{
    using System;

    public class ValidationEventArgs
        : EventArgs
    {
        string _message;
        
        public string Message
        {
            get { return _message; }
        }

        public ValidationEventArgs(string message)
        {
            _message = message;
        }
    }
}

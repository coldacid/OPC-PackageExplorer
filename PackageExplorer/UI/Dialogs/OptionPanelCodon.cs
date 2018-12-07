using System;
using System.Collections.Generic;
using System.Text;
using PackageExplorer.Core.AddInModel.Codons;
using System.Collections;
using PackageExplorer.Core.AddInModel;

namespace PackageExplorer.UI.Dialogs
{
    [CodonName("OptionPanel")]
    [RequiredAttribute("title")]
    class OptionPanelCodon
        : CodonBase
    {
        string _title;
        string _class;
        string _defaultChildPane;

        public string Title
        {
            get { return _title; }
            set { _title = value; }
        }

        public string Class
        {
            get { return _class; }
            set { _class = value; }
        }
        
        public string DefaultChildPane
        {
            get { return _defaultChildPane; }
            set { _defaultChildPane = value; }
        }

        public override object BuildItem(
            object owner, ArrayList subItems)
        {
            return AddIn.CreateObject(_class);
        }
    }
}

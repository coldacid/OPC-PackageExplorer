using System;
using PackageExplorer.Core;
using PackageExplorer.UI.Workbench;
using PackageExplorer.Core.Services;
using PackageExplorer.Core.AddInModel.Codons;
using PackageExplorer.Services;

namespace PackageExplorer.AddIns.AddInScout
{
    class ViewAddInScoutCommand
        : ICommand
    {
        public string Name
        {
            get { return "View.AddInScout"; }
        }

        public ViewAddInScoutCommand()
        {
                
        }

        public void Execute()
        {
            ContentExplorer explorer = new ContentExplorer();

            StringParserService parser = ServiceManager.GetService<StringParserService>();
            WorkbenchService service = ServiceManager.GetService<WorkbenchService>();
            IWindow window = service.CreateInspectorWindow(explorer,
                parser.Parse("{RES: AddInScout, Title}"),
                null);
            window.Show();
        }
    }
}

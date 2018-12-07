using System;
using PackageExplorer.Core;
using PackageExplorer.ObjectModel;

namespace PackageExplorer.Commands
{
    class QuitCommand
        : CommandBase
    {
        public QuitCommand()
            : base("File.Quit")
        {
        }

        public override void Execute()
        {
            Application.Exit();
        }
    }
}

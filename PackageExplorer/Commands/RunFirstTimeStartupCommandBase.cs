using System;
using System.Configuration;
using PackageExplorer.Services;
using PackageExplorer.Core.Services;
using PackageExplorer.UI.Workbench;
using PackageExplorer.ObjectModel;

namespace PackageExplorer.Commands
{
    public abstract class RunFirstTimeStartupCommandBase
        : CommandBase
    {
        public RunFirstTimeStartupCommandBase(string commandName)
            : base(commandName)
        {
        }

        public override void Execute()
        {
            if (FirstTimeStartup.IsFirstTimeStartup)
            {
                PerformFirstTimeStartup();
            }
        }

        protected abstract void PerformFirstTimeStartup();
    }
}

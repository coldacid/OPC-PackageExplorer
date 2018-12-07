using System;
using PackageExplorer.Core.Services;
using PackageExplorer.UI.Menu;
using System.Collections.Generic;
using ToolStrip = System.Windows.Forms.ToolStrip;
namespace PackageExplorer.Services
{
    public interface IToolStripService
        : IService
    {
        List<ToolStrip> CreateToolStrips(string treePath);
    }
}

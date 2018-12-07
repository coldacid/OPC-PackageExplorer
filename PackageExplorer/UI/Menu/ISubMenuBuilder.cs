using System;
using System.Collections.Generic;

namespace PackageExplorer.UI.Menu
{
    public interface ISubMenuBuilder
    {
        IEnumerable<ToolStripMenuItem> BuildSubMenu();
    }
}

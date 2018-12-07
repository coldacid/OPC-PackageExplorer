using System;
using System.Collections.Generic;

namespace PackageExplorer.UI.Menu
{
    public interface IComboBoxBuilder
    {
        IEnumerable<ToolStripComboBoxItem> BuildComboBox();
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WpfExplorer.Support.UI.Units;

namespace WpfExplorer.Forms.UI.Views
{
    public class ExplorerWindow : DarkWindow
    {
        static ExplorerWindow()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ExplorerWindow), 
                new FrameworkPropertyMetadata(typeof(ExplorerWindow)));
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WpfExplorer.Forms.UI.Views;
using WpfExplorer.Support.UI.Units;

namespace WpfExplorer
{
    internal class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            DarkWindow win = new DarkWindow();
            win.Title = "James";
            win.ShowDialog();
        }
    }
}

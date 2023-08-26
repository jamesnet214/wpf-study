using System.Windows;
using System.Windows.Controls;

namespace WpfExplorer.Support.UI.Units
{
    public class DarkWindow : Window
    {
        static DarkWindow()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(DarkWindow),
                new FrameworkPropertyMetadata(typeof(DarkWindow)));
        }

        public DarkWindow()
        {
            WindowStyle = WindowStyle.None;
            AllowsTransparency = true;
        }
    }
}

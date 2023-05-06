using System.Windows;
using WpfCustomApp.UI.Views;

namespace WpfCustomApp
{
    public class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            PracticeWindow window = new();
            window.ShowDialog();
        }
    }
}
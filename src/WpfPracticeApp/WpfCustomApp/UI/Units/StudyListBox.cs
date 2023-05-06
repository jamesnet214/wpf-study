using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfCustomApp.UI.Views;

namespace WpfCustomApp.UI.Units
{
    public class StudyListBox : ListBox
    {
        static StudyListBox()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(StudyListBox), new FrameworkPropertyMetadata(typeof(StudyListBox)));
        }

        public StudyListBox()
        {

            ItemsSource = GetSamples();
        }

        private IEnumerable GetSamples()
        {
            List<User> users = new();
            users.Add(new User().GenData("James", "Seoul"));
            users.Add(new User().GenData("Vicky", "Napoli"));
            users.Add(new User().GenData("Harry", "Paris"));
            users.Add(new User().GenData("Luke", "London"));

            return users;
        }

        protected override DependencyObject GetContainerForItemOverride()
        {
            return new StudyListBoxItem();
        }
    }
}

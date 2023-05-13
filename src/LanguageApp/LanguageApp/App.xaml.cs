using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace LanguageApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private static Dictionary<string, ResourceDictionary> _languages;
        private static ResourceDictionary _currentLanguage;

        public App()
        {
            ResourceDictionary korean = GetResource("Korean");
            ResourceDictionary english = GetResource("English");

            _languages = new();
            _languages.Add("KOR", korean);
            _languages.Add("ENG", english);

            //_currentLanguage = korean;
            //Resources.MergedDictionaries.Add(korean);
        }

        private ResourceDictionary GetResource(string nation)
        {
            ResourceDictionary resource = new();
            resource.Source = new Uri($"/LanguageApp;component/Themes/{nation}.xaml", UriKind.RelativeOrAbsolute);

            return resource;
        }

        internal static void SwitchLanguage(LanguageModel language)
        {
            App.Current.Resources.MergedDictionaries.Remove(_currentLanguage);
            App.Current.Resources.MergedDictionaries.Add(_languages[language.Code]);
        }
    }
}

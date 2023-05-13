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

        private static Dictionary<string, ResourceDictionary> _themes;
        private static ResourceDictionary _currentTheme;

        public App()
        {
            #region Languages

            ResourceDictionary korean = GetResource("Korean");
            ResourceDictionary english = GetResource("English");
            ResourceDictionary chinese = GetResource("Chinese");

            _languages = new();
            _languages.Add("KOR", korean);
            _languages.Add("ENG", english);
            _languages.Add("CHN", chinese);
            #endregion

            #region Themes

            ResourceDictionary dark = GetResource("Dark");
            ResourceDictionary white = GetResource("White");

            _themes = new();
            _themes.Add("DAK", dark);
            _themes.Add("WHI", white);
            #endregion
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

        internal static void SwitchTheme(ThemeModel theme)
        {
            App.Current.Resources.MergedDictionaries.Remove(_currentTheme);
            App.Current.Resources.MergedDictionaries.Add(_themes[theme.Code]);
        }
    }
}

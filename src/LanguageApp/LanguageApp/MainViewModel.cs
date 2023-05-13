using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Documents;
using System.Xml.Linq;

namespace LanguageApp
{
    public class MainViewModel : ObservableObject
    {
        private LanguageModel _language;
        private ThemeModel _theme;

        public List<LanguageModel> Languages { get; init; }
        public List<ThemeModel> Themes { get; init; }

        public LanguageModel Language
        {
            get => _language;
            set => SetProperty2(ref _language, value, LanguageChanged);
        }

        public ThemeModel Theme
        {
            get => _theme;
            set => SetProperty2(ref _theme, value, ThemeChanged);
        }

        public MainViewModel()
        {
            Languages = GetLanguages();
            Language = Languages.FirstOrDefault();

            Themes = GetThemes();
            Theme = Themes.FirstOrDefault();
        }

        private List<LanguageModel> GetLanguages()
        {
            List<LanguageModel> source = new();
            source.Add(new LanguageModel().DataGen("KOR", "Korean"));
            source.Add(new LanguageModel().DataGen("ENG", "English"));
            source.Add(new LanguageModel().DataGen("CHN", "Chinese"));
            return source;
        }

        private List<ThemeModel> GetThemes()
        {
            List<ThemeModel> source = new();
            source.Add(new ThemeModel().DataGen("DAK", "Dark"));
            source.Add(new ThemeModel().DataGen("WHI", "White"));
            return source;
        }

        private void LanguageChanged(LanguageModel value)
        {
            App.SwitchLanguage(value);
        }

        private void ThemeChanged(ThemeModel value)
        {
            App.SwitchTheme(value);
        }

        private void SetProperty2<T>(ref T value1, T value2, Action<T> changed, [CallerMemberName] string name = null)
        {
            OnPropertyChanged(name);
            value1 = value2;
            changed.Invoke(value2);
        }
    }
}

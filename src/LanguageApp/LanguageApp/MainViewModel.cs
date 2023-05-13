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

        public List<TeamModel> Teams { get; private set; }

        public MainViewModel()
        {
            Languages = GetLanguages();
            Language = Languages.FirstOrDefault();

            Themes = GetThemes();
            Theme = Themes.FirstOrDefault();

            Teams = GetTeams();
        }

        private List<TeamModel> GetTeams()
        {
            List<TeamModel> source = new();
            source.Add(new TeamModel().DataGen("EPL", null, "잉글랜드"));
            source.Add(new TeamModel().DataGen("SPL", null, "스페인"));
            source.Add(new TeamModel().DataGen("ITL", null, "이탈리아"));

            source[0].Children.Add(new TeamModel().DataGen("TOT", "EPL", "토트넘"));
            source[0].Children.Add(new TeamModel().DataGen("ARS", "EPL", "아스널"));
            source[0].Children.Add(new TeamModel().DataGen("CHE", "EPL", "첼시"));

            source[0].Children[0].Children.Add(new TeamModel().DataGen("07", "TOT", "손흥민"));
            source[0].Children[0].Children.Add(new TeamModel().DataGen("19", "TOT", "이강인"));
            source[0].Children[0].Children.Add(new TeamModel().DataGen("05", "TOT", "김민재"));
            return source;
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

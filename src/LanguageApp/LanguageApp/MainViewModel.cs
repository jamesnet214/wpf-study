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
        private LanguageModel _languageModel;

        public List<LanguageModel> Languages { get; set; }

        public LanguageModel Language
        {
            get => _languageModel;
            set => SetProperty2(ref _languageModel, value, LanguageModelChanged);
        }

        public MainViewModel()
        {
            Languages = GetLanguages();
            Language= Languages.FirstOrDefault();   
        }

        private List<LanguageModel> GetLanguages()
        {
            List<LanguageModel> source = new();
            source.Add(new LanguageModel().DataGen("KOR", "Korean"));
            source.Add(new LanguageModel().DataGen("ENG", "English"));
            source.Add(new LanguageModel().DataGen("CHN", "Chinese"));
            return source;
        }

        private void LanguageModelChanged(LanguageModel value)
        {
            App.SwitchLanguage(value);
        }

        private void SetProperty2<T>(ref T value1, T value2, Action<T> changed, [CallerMemberName] string name = null)
        {
            OnPropertyChanged(name);
            value1 = value2;
            changed.Invoke(value2);
        }
    }
}

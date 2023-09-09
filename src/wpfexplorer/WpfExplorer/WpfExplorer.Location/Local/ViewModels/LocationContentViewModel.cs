using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Jamesnet.Wpf.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfExplorer.Support.Local.Helpers;
using WpfExplorer.Support.Local.Models;

namespace WpfExplorer.Location.Local.ViewModels
{
    public partial class LocationContentViewModel : ObservableBase
    {
        private readonly NavigatorService _navigatorService;

        [ObservableProperty]
        private FileInfoBase _current;

        public LocationContentViewModel(NavigatorService navigatorService)
        {
            _navigatorService = navigatorService;
            _navigatorService.LocationChanged += _navigatorService_LocationChanged;
        }

        private void _navigatorService_LocationChanged(object? sender, Support.Local.Models.LocationChangedEventArgs e)
        {
            Current = e.Current;
        }

        [RelayCommand]
        private void GoBack()
        {
            _navigatorService.GoBack();
        }
    }
}

using CommunityToolkit.Mvvm.Input;
using Jamesnet.Wpf.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using WpfExplorer.Support.Local.Helpers;
using WpfExplorer.Support.Local.Models;

namespace WpfExplorer.Main.Local.ViewModels
{
    public partial class MainContentViewModel : ObservableBase
    {
        private readonly FileService _fileService;

        public List<FolderInfo> Roots { get; init; }

        public MainContentViewModel(FileService fileService)
        {
            _fileService = fileService;
            Roots = _fileService.GenerateRootNodes();
        }

        [RelayCommand]
        private void FolderChanged(FolderInfo item)
        {
            _fileService.RefreshSubdirectories(item);
        }
    }
}

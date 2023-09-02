using CommunityToolkit.Mvvm.ComponentModel;
using Jamesnet.Wpf.Controls;
using Jamesnet.Wpf.Mvvm;
using Prism.Ioc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WpfExplorer.Support.Local.Helpers;

namespace WpfExplorer.Forms.Local.ViewModels
{
    public partial class ExplorerViewModel : ObservableBase, IViewLoadable
    {
        private readonly IContainerProvider _containerProvider;

        [ObservableProperty]
        private object _content;

        public ExplorerViewModel(DirectoryManager directoryManager, IContainerProvider containerProvider) 
        {
            _containerProvider = containerProvider;
        }

        public void OnLoaded(IViewable view)
        {
            IViewable main = _containerProvider.Resolve<IViewable>("MainContent");
            Content = main;
        }
    }
}

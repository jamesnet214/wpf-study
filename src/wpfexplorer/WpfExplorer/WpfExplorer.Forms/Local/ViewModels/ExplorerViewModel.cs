using CommunityToolkit.Mvvm.ComponentModel;
using Jamesnet.Wpf.Controls;
using Jamesnet.Wpf.Mvvm;
using Prism.Ioc;
using Prism.Regions;
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
        private readonly IRegionManager _regionManager;
        [ObservableProperty]
        private object _content;

        public ExplorerViewModel(DirectoryManager directoryManager, IContainerProvider containerProvider, IRegionManager regionManager) 
        {
            _containerProvider = containerProvider;
            _regionManager = regionManager;
        }

        public void OnLoaded(IViewable view)
        {
            ImportContent("MainContent", "MainRegion");
            ImportContent("LocationContent", "LocationRegion");
        }

        private void ImportContent(string contentName, string regionName)
        {
            IViewable content = _containerProvider.Resolve<IViewable>(contentName);
            IRegion region = _regionManager.Regions[regionName];

            if (!region.Views.Contains(content))
            {
                region.Add(content);
            }
            region.Activate(content);
        }
    }
}

using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfExplorer.Support.Local.Models
{
    public partial class FolderInfo : FileInfoBase
    {
        [ObservableProperty]
        private bool _isFolderExpanded;
        [ObservableProperty]
        private bool _isFolderSelected;

        public ObservableCollection<FolderInfo> Children { get; set; }
    }
}

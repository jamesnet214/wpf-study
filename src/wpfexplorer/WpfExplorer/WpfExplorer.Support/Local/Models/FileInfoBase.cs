using CommunityToolkit.Mvvm.ComponentModel;
using Jamesnet.Wpf.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfExplorer.Support.Local.Models
{
    public partial class FileInfoBase : ObservableObject
    {
        [ObservableProperty]
        private bool _isDenied;

        public string Name { get; set; }
        public string FullPath { get; set; }
        public int Depth { get; set; }
        public long Length { get; set; }
        public IconType IconType { get; set; }
    }
}

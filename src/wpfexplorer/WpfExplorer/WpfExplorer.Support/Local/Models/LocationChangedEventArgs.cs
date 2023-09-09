using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfExplorer.Support.Local.Models
{
    public class LocationChangedEventArgs : EventArgs
    {
        public FileInfoBase Current { get; init; }

        public LocationChangedEventArgs(FileInfoBase current)
        {
            Current = current;
        }
    }
}

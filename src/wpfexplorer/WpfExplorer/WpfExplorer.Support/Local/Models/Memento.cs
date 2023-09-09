using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfExplorer.Support.Local.Models
{
    internal class Memento
    {
        private string _fullPath;

        public Memento(string fullpath)
        {
            _fullPath = fullpath;
        }

        public string GetSavedFullPath()
        {
            return _fullPath;
        }
    }
}

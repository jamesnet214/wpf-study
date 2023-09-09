using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfExplorer.Support.Local.Models;

namespace WpfExplorer.Support.Local.Helpers
{
    public class NavigatorService
    {
        private FileInfoBase currentLocation;
        private Stack<Memento> backStack = new Stack<Memento>();
        private Stack<Memento> forwardStack = new Stack<Memento>();

        public event EventHandler<LocationChangedEventArgs> LocationChanged;

        public void ChangeLocation(FileInfoBase newLocation)
        {
            if (currentLocation != null)
            {
                SaveState();
            }

            currentLocation = newLocation;
            OnLocationChanged(new LocationChangedEventArgs(currentLocation));
        }

        private void SaveState()
        {
            backStack.Push(new Memento(currentLocation.FullPath));
        }

        public void GoBack()
        {
            if (backStack.Any())
            {
                RestoreState(backStack, forwardStack);
            }
        }

        private void RestoreState(Stack<Memento> popFrom, Stack<Memento> pushTo)
        {
            pushTo.Push(new Memento(currentLocation.FullPath));
            currentLocation.FullPath = popFrom.Pop().GetSavedFullPath();
            OnLocationChanged(new LocationChangedEventArgs(currentLocation));
        }

        private void OnLocationChanged(LocationChangedEventArgs e)
        {
            LocationChanged?.Invoke(this, e);
        }
    }
}

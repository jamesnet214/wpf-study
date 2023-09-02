using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using WpfExplorer.Support.Local.Models;

namespace WpfExplorer.Main.UI.Units
{
    public class FolderTreeView : TreeView
    {
        public static readonly DependencyProperty SelectionCommandProperty =
            DependencyProperty.Register("SelectionCommand", typeof(ICommand), typeof(FolderTreeView));

        public ICommand SelectionCommand
        { 
            get => (ICommand)GetValue(SelectionCommandProperty);
            set => SetValue(SelectionCommandProperty, value);
        }

        static FolderTreeView()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(FolderTreeView),
                new FrameworkPropertyMetadata(typeof(FolderTreeView)));
        }

        protected override DependencyObject GetContainerForItemOverride()
        {
            return new FolderTreeItem();
        }

        public FolderTreeView()
        {
            SelectedItemChanged += FolderTreeView_SelectedItemChanged;
        }

        private void FolderTreeView_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            if (SelectedItem is FolderInfo item)
            {
                SelectionCommand?.Execute(item);
            }
        }
    }
}

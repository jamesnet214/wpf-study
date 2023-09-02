using System.Windows;
using System.Windows.Controls;

namespace WpfExplorer.Main.UI.Units
{
    public class FolderTreeView : TreeView
    {
        static FolderTreeView()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(FolderTreeView),
                new FrameworkPropertyMetadata(typeof(FolderTreeView)));
        }

        protected override DependencyObject GetContainerForItemOverride()
        {
            return new FolderTreeItem();
        }
    }
}

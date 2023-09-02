using System.Windows;
using System.Windows.Controls;

namespace WpfExplorer.Forms.UI.Units
{
    public class FolderTreeItem : TreeViewItem
    {
        static FolderTreeItem()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(FolderTreeItem), new FrameworkPropertyMetadata(typeof(FolderTreeItem)));
        }
    }
}

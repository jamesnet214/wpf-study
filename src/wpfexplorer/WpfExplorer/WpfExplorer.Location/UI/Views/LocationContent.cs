﻿using Jamesnet.Wpf.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfExplorer.Location.UI.Views
{
    public class LocationContent : JamesContent
    {
        static LocationContent()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(LocationContent), new FrameworkPropertyMetadata(typeof(LocationContent)));
        }
    }
}

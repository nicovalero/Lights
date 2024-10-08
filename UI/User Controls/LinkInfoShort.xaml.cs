﻿using System;
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
using UI.Models.Structs;

namespace UI.User_Controls
{
    /// <summary>
    /// Interaction logic for LinkInfo.xaml
    /// </summary>
    public partial class LinkInfoShort : UserControl
    {
        public LinkInfoShort()
        {
            InitializeComponent();
        }

        public FontAwesome.Sharp.IconChar Icon
        {
            get { return (FontAwesome.Sharp.IconChar)GetValue(IconProperty); }
            set { SetValue(IconProperty, value); }
        }

        public static readonly DependencyProperty IconProperty = DependencyProperty.Register("Icon", typeof(FontAwesome.Sharp.IconChar), typeof(LinkInfoShort));

        internal List<MidiEffectLink_ViewModel> Source
        {
            get { return (List<MidiEffectLink_ViewModel>)GetValue(SourceProperty); }
            set { SetValue(SourceProperty, value); }
        }

        public static readonly DependencyProperty SourceProperty = DependencyProperty.Register("Source", typeof(List<MidiEffectLink_ViewModel>), typeof(LinkInfoShort));

        public event RoutedEventHandler OnDeleteClick;

        private void deleteButton_Click(object sender, RoutedEventArgs args)
        {
            if (OnDeleteClick != null)
                OnDeleteClick(this, args);
        }

        public event RoutedEventHandler OnMouseDoubleClick;

        private void LinkList_MouseDoubleClick(object sender, MouseButtonEventArgs args)
        {
            if (OnMouseDoubleClick != null)
                OnMouseDoubleClick(sender, args);
        }
    }
}

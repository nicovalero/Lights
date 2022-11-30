using GongSolutions.Wpf.DragDrop.Utilities;
using MIDI.Models.Structs;
using PhilipsHue.Models.Interfaces;
using System;
using System.Collections;
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
using UI.Models.Interfaces;
using UI.Models.Structs;

namespace UI.User_Controls
{
    /// <summary>
    /// Interaction logic for DoubleColumnListConfigCard.xaml
    /// </summary>
    public partial class DoubleColumnListConfigCard : UserControl
    {
        public DoubleColumnListConfigCard()
        {
            InitializeComponent();
        }

        public string Title
        {
            get { return (string)GetValue(TitleProperty); }
            set { SetValue(TitleProperty, value); }
        }

        public static readonly DependencyProperty TitleProperty = DependencyProperty.Register("Title", typeof(string), typeof(DoubleColumnListConfigCard));

        internal List<CardConfigList_ViewModel> Source
        {
            get { return (List<CardConfigList_ViewModel>)GetValue(SourceProperty); }
            set { SetValue(SourceProperty, value); }
        }

        internal static readonly DependencyProperty SourceProperty = DependencyProperty.Register("Source", typeof(List<CardConfigList_ViewModel>), typeof(DoubleColumnListConfigCard));

        internal SelectionMode ListSelectionMode
        {
            get { return (SelectionMode)GetValue(ListSelectionModeProperty); }
            set { SetValue(ListSelectionModeProperty, value); }
        }

        internal static readonly DependencyProperty ListSelectionModeProperty = DependencyProperty.Register("ListSelectionMode", typeof(SelectionMode), typeof(DoubleColumnListConfigCard));

        public object SelectedItem
        {
            get { return ItemList.SelectedItem; }
        }

        public IList SelectedItems
        {
            get { return ItemList.SelectedItems; }
        }

        internal void SelectItem(string key)
        {
            for (int i = 0; i < ItemList.Items.Count; i++)
            {
                if (ItemList.Items[i] is CardConfigList_ViewModel card)
                {
                    if (card.ItemID.ToLower() == key.ToLower())
                    {
                        ItemList.SelectedItem = card;
                        break;
                    }
                }
            }
        }

        internal void SelectItems(HashSet<string> keys)
        {
            for (int i = 0; i < ItemList.Items.Count; i++)
            {
                if (ItemList.Items[i] is CardConfigList_ViewModel card)
                {
                    if (keys.Contains(card.ItemID))
                    {
                        ItemList.SetItemSelected(card, true);
                    }
                    else
                    {
                        ItemList.SetItemSelected(card, false);
                    }
                }
            }
        }
    }
}

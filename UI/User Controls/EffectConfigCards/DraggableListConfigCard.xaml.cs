using MIDI.Models.Structs;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace UI.User_Controls.EffectConfigCards
{
    /// <summary>
    /// Interaction logic for LinkListConfigCard.xaml
    /// </summary>
    public partial class DraggableListConfigCard : UserControl
    {
        public DraggableListConfigCard()
        {
            InitializeComponent();
        }

        public string Title
        {
            get { return (string)GetValue(TitleProperty); }
            set { SetValue(TitleProperty, value); }
        }

        public static readonly DependencyProperty TitleProperty = DependencyProperty.Register("Title", typeof(string), typeof(DraggableListConfigCard));

        public Color CardBackground
        {
            get { return (Color)GetValue(CardBackgroundProperty); }
            set { SetValue(CardBackgroundProperty, value); }
        }

        public static readonly DependencyProperty CardBackgroundProperty = DependencyProperty.Register("CardBackground", typeof(Color), typeof(DraggableListConfigCard));

        internal ObservableCollection<IConfigListViewModel> Source
        {
            get { return (ObservableCollection<IConfigListViewModel>)GetValue(SourceProperty); }
            set { SetValue(SourceProperty, value); }
        }

        internal static readonly DependencyProperty SourceProperty = DependencyProperty.Register("Source", typeof(ObservableCollection<IConfigListViewModel>), typeof(DraggableListConfigCard));

        public FontAwesome.Sharp.IconChar ElementIcon
        {
            get { return (FontAwesome.Sharp.IconChar)GetValue(ElementIconProperty); }
            set { SetValue(ElementIconProperty, value); }
        }

        public static readonly DependencyProperty ElementIconProperty = DependencyProperty.Register("ElementIcon", typeof(FontAwesome.Sharp.IconChar), typeof(DraggableListConfigCard));

        internal ItemCollection ItemCollection
        {
            get { return ItemList.Items; }
        }
    }
}

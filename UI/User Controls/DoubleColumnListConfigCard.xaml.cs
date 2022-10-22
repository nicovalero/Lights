using MIDI.Models.Structs;
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

        public Color CardBackground
        {
            get { return (Color)GetValue(CardBackgroundProperty); }
            set { SetValue(CardBackgroundProperty, value); }
        }

        public static readonly DependencyProperty CardBackgroundProperty = DependencyProperty.Register("CardBackground", typeof(Color), typeof(DoubleColumnListConfigCard));

        internal List<SimpleConfigList_ViewModel> Source
        {
            get { return (List<SimpleConfigList_ViewModel>)GetValue(SourceProperty); }
            set { SetValue(SourceProperty, value); }
        }

        internal static readonly DependencyProperty SourceProperty = DependencyProperty.Register("Source", typeof(List<SimpleConfigList_ViewModel>), typeof(DoubleColumnListConfigCard));
    }
}

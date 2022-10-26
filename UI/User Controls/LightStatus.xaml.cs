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

namespace UI.User_Controls
{
    /// <summary>
    /// Interaction logic for LightStatus.xaml
    /// </summary>
    public partial class LightStatus : UserControl
    {
        public LightStatus()
        {
            InitializeComponent();
        }

        public string Title
        {
            get { return (string)GetValue(TitleProperty); }
            set { SetValue(TitleProperty, value); }
        }

        public static readonly DependencyProperty TitleProperty = DependencyProperty.Register("Title", typeof(string), typeof(LightStatus));

        public string Subtitle
        {
            get { return (string)GetValue(SubtitleProperty); }
            set { SetValue(SubtitleProperty, value); }
        }

        public static readonly DependencyProperty SubtitleProperty = DependencyProperty.Register("Subtitle", typeof(string), typeof(LightStatus));

        public FontAwesome.Sharp.IconChar Icon
        {
            get { return (FontAwesome.Sharp.IconChar)GetValue(IconProperty); }
            set { SetValue(IconProperty, value); }
        }

        public static readonly DependencyProperty IconProperty = DependencyProperty.Register("Icon", typeof(FontAwesome.Sharp.IconChar), typeof(LightStatus));
    }
}

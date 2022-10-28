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
    /// Interaction logic for WindowUtils.xaml
    /// </summary>
    public partial class WindowUtils : UserControl
    {
        public WindowUtils()
        {
            InitializeComponent();
        }

        public event RoutedEventHandler MinimizeClick;
        private void minimizeButton_Click(object sender, RoutedEventArgs args)
        {
            if (MinimizeClick != null)
                MinimizeClick(this, args);
        }

        public event RoutedEventHandler CloseClick;
        private void closeButton_Click(object sender, RoutedEventArgs args)
        {
            if (CloseClick != null)
                CloseClick(this, args);
        }

        public Visibility ShowMinimizeButton
        {
            get { return (Visibility)GetValue(ShowMinimizeButtonProperty); }
            set { SetValue(ShowMinimizeButtonProperty, value); }
        }

        public static readonly DependencyProperty ShowMinimizeButtonProperty = DependencyProperty.Register("ShowMinimizeButton", typeof(Visibility), typeof(WindowUtils));
    }
}

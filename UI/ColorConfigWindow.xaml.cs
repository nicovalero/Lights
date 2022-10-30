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
using System.Windows.Shapes;
using UI.Models.Structs;
using UI.User_Controls.EffectConfigCards;

namespace UI
{
    /// <summary>
    /// Interaction logic for ColorConfigWindow.xaml
    /// </summary>
    public partial class ColorConfigWindow : Window
    {
        private ColorConfig_ViewModel _colorConfig;
        internal ColorConfig_ViewModel ColorConfig { get { return _colorConfig; } set { _colorConfig = value; } }
        internal ColorConfigWindow()
        {
            _colorConfig = new ColorConfig_ViewModel();
            InitializeComponent();
        }

        internal ColorConfigWindow(ColorConfig_ViewModel colorConfig)
        {
            _colorConfig = colorConfig;
            InitializeComponent();
            RefreshColorInCard();
        }

        private void WindowUtils_CloseClick(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }
        }

        private void RefreshColorInCard()
        {
            ColorCard.SelectedColor = ColorConfig.SelectedColor;
        }

        private void ColorCard_SelectedColorChanged(object sender, RoutedEventArgs e)
        {
            _colorConfig.SelectedColor = ((ColorConfigCard)sender).SelectedColor;
        }
    }
}

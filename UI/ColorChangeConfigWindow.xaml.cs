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
using UI.Models.ViewModel_Config_Sets;
using UI.User_Controls.EffectConfigCards;

namespace UI
{
    /// <summary>
    /// Interaction logic for ColorConfigWindow.xaml
    /// </summary>
    public partial class ColorChangeConfigWindow : Window
    {
        private ColorChangeConfig_VMSet _colorChangeConfigSet;
        internal ColorChangeConfig_VMSet ColorChangeConfigSet { get { return _colorChangeConfigSet; } set { _colorChangeConfigSet = value; } }

        internal ColorChangeConfigWindow()
        {
            _colorChangeConfigSet = new ColorChangeConfig_VMSet(new ColorConfig_ViewModel());
            InitializeComponent();
        }

        internal ColorChangeConfigWindow(ColorChangeConfig_VMSet configSet)
        {
            if(configSet != null)
                _colorChangeConfigSet = configSet;
            else
                _colorChangeConfigSet = new ColorChangeConfig_VMSet();
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
            ColorCard.SelectedColor = ColorChangeConfigSet.FinalColor.SelectedColor;
        }

        private void ColorCard_SelectedColorChanged(object sender, RoutedEventArgs e)
        {
            Color? newColor = ((ColorConfigCard)sender).SelectedColor;
            ColorChangeConfigSet.FinalColor = new ColorConfig_ViewModel(newColor);
        }
    }
}

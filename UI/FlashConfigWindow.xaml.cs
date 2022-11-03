using PhilipsHue.EffectConfig.Creators.Classes;
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
using UI.Models.ViewModel_Config_Sets.Classes;
using UI.User_Controls.EffectConfigCards;

namespace UI
{
    /// <summary>
    /// Interaction logic for ColorConfigWindow.xaml
    /// </summary>
    public partial class FlashConfigWindow : Window
    {
        private FlashConfig_VMSet _flashConfigSet;
        internal FlashConfig_VMSet FlashConfigSet { get { return _flashConfigSet; } set { _flashConfigSet = value; } }

        internal FlashConfigWindow()
        {
            _flashConfigSet = new FlashConfig_VMSet(new BrightnessConfig_ViewModel(), new BrightnessConfig_ViewModel());
            InitializeComponent();
        }

        internal FlashConfigWindow(FlashConfig_VMSet configSet)
        {
            if(configSet != null)
                _flashConfigSet = configSet;
            else
                _flashConfigSet = new FlashConfig_VMSet(new BrightnessConfig_ViewModel(), new BrightnessConfig_ViewModel());
            InitializeComponent();
            RefreshValuesInCard();
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

        private void RefreshValuesInCard()
        {
            
        }

        private void FirstBrightnessCard_SelectedColorChanged(object sender, RoutedEventArgs e)
        {
            //byte newBrightness = ((BrightnessConfigCard)sender).SelectedValue;
            //FlashConfigSet.FirstBrightnessLevel = new BrightnessConfig_ViewModel(newBrightness);
        }
        private void SecondBrightnessCard_SelectedColorChanged(object sender, RoutedEventArgs e)
        {
            //byte newBrightness = ((BrightnessConfigCard)sender).SelectedValue;
            //FlashConfigSet.SecondBrightnessLevel = new BrightnessConfig_ViewModel(newBrightness);
        }
    }
}

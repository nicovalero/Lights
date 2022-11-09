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
    public partial class FadeInConfigWindow : Window
    {
        private FadeInConfig_VMSet _fadeInConfigSet;
        internal FadeInConfig_VMSet FadeInConfigSet { get { return _fadeInConfigSet; } set { _fadeInConfigSet = value; } }

        internal FadeInConfigWindow()
        {
            _fadeInConfigSet = new FadeInConfig_VMSet(new BrightnessConfig_ViewModel());
            InitializeComponent();
        }

        internal FadeInConfigWindow(FadeInConfig_VMSet configSet)
        {
            if(configSet != null)
                _fadeInConfigSet = configSet;
            else
                _fadeInConfigSet = new FadeInConfig_VMSet(new BrightnessConfig_ViewModel());
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
            BrightnessCard.BrightnessLevel = _fadeInConfigSet.BrightnessLevel.BrightnessLevel;
        }

        private void BrightnessCard_BrightnessLevelChanged(object sender, RoutedEventArgs e)
        {
            FadeInConfigSet.BrightnessLevel = new BrightnessConfig_ViewModel(BrightnessCard.BrightnessLevel);
        }
    }
}

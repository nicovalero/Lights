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
    public partial class FadeOutConfigWindow : Window
    {
        private FadeOutConfig_VMSet _fadeOutConfigSet;
        internal FadeOutConfig_VMSet FadeOutConfigSet { get { return _fadeOutConfigSet; } set { _fadeOutConfigSet = value; } }

        internal FadeOutConfigWindow()
        {
            _fadeOutConfigSet = new FadeOutConfig_VMSet(new BrightnessConfig_ViewModel(), new TransitionTimeConfig_ViewModel());
            InitializeComponent();
        }

        internal FadeOutConfigWindow(FadeOutConfig_VMSet configSet)
        {
            if(configSet != null)
                _fadeOutConfigSet = configSet;
            else
                _fadeOutConfigSet = new FadeOutConfig_VMSet(new BrightnessConfig_ViewModel(), new TransitionTimeConfig_ViewModel());
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
            RefreshTransitionTimeCard();
            RefreshBrightnessCard();
        }

        private void RefreshTransitionTimeCard()
        {
            TransitionTimeCard.TimeInTenthOfSecond = FadeOutConfigSet.TransitionTime.TransitionTime;
        }

        private void RefreshBrightnessCard()
        {
            BrightnessCard.BrightnessLevel = FadeOutConfigSet.BrightnessLevel.BrightnessLevel;
        }

        private void BrightnessCard_BrightnessLevelChanged(object sender, RoutedEventArgs e)
        {
            FadeOutConfigSet.BrightnessLevel = new BrightnessConfig_ViewModel(BrightnessCard.BrightnessLevel);
        }

        private void TransitionTimeCard_TransitionTimeChanged(object sender, RoutedEventArgs e)
        {
            FadeOutConfigSet.TransitionTime = new TransitionTimeConfig_ViewModel(TransitionTimeCard.TimeInTenthOfSecond);
        }
    }
}

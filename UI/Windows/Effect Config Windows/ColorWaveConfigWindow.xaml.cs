using PhilipsHue.EffectConfig.Creators.Classes;
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
using System.Windows.Shapes;
using UI.Models.Interfaces;
using UI.Models.Structs;
using UI.Models.ViewModel_Config_Sets.Classes;
using UI.User_Controls;
using UI.User_Controls.EffectConfigCards;

namespace UI
{
    /// <summary>
    /// Interaction logic for BrightnessWaveConfigWindow.xaml
    /// </summary>
    public partial class ColorWaveConfigWindow : Window
    {
        private ColorWaveConfig_VMSet _colorWaveConfigSet;
        internal ColorWaveConfig_VMSet ColorWaveConfigSet { get { return _colorWaveConfigSet; } set { _colorWaveConfigSet = value; } }

        internal ColorWaveConfigWindow()
        {
            _colorWaveConfigSet = new ColorWaveConfig_VMSet(new ColorConfig_ViewModel(), new LightListConfig_ViewModel() ,new TransitionTimeConfig_ViewModel(), new TransitionTimeConfig_ViewModel());
            InitializeComponent();
        }

        internal ColorWaveConfigWindow(ColorWaveConfig_VMSet configSet)
        {
            if(configSet != null)
                _colorWaveConfigSet = configSet;
            else
                _colorWaveConfigSet = new ColorWaveConfig_VMSet(new ColorConfig_ViewModel(), new LightListConfig_ViewModel(), new TransitionTimeConfig_ViewModel(), new TransitionTimeConfig_ViewModel());
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
            RefreshTransitionTimeInCard();
            RefreshIntervalTimeInCard();
            RefreshValuesInColorCard();
            RefreshLightListInCard();
        }

        private void RefreshLightListInCard()
        {
            Resources["ColorWaveWindowLightListSource"] = ColorWaveConfigSet.LightList.Collection;
        }

        private void RefreshValuesInColorCard()
        {
            ColorCard.SelectedColor = ColorWaveConfigSet.FinalColor.SelectedColor;
        }
        private void RefreshTransitionTimeInCard()
        {
            TransitionTimeCard.TimeInTenthOfSecond = ColorWaveConfigSet.TransitionTime.TransitionTime;
        }

        private void RefreshIntervalTimeInCard()
        {
            IntervalTimeCard.TimeInTenthOfSecond = ColorWaveConfigSet.IntervalTime.TransitionTime;
        }

        private void ColorCard_SelectedColorChanged(object sender, RoutedEventArgs e)
        {
            Color? newColor = ((ColorConfigCard)sender).SelectedColor;
            ColorWaveConfigSet.FinalColor = new ColorConfig_ViewModel(newColor);
        }

        private void TransitionTimeCard_TransitionTimeChanged(object sender, RoutedEventArgs e)
        {
            ColorWaveConfigSet.TransitionTime = new TransitionTimeConfig_ViewModel(TransitionTimeCard.TimeInTenthOfSecond);
        }

        private void IntervalTimeCard_TransitionTimeChanged(object sender, RoutedEventArgs e)
        {
            ColorWaveConfigSet.IntervalTime = new TransitionTimeConfig_ViewModel(IntervalTimeCard.TimeInTenthOfSecond);
        }
    }
}

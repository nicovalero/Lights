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
    public partial class BrightnessWaveConfigWindow : Window
    {
        private BrightnessWaveConfig_VMSet _brightnessWaveConfigSet;
        internal BrightnessWaveConfig_VMSet BrightnessWaveConfigSet { get { return _brightnessWaveConfigSet; } set { _brightnessWaveConfigSet = value; } }

        internal BrightnessWaveConfigWindow()
        {
            _brightnessWaveConfigSet = new BrightnessWaveConfig_VMSet(new BrightnessConfig_ViewModel(), new LightListConfig_ViewModel() ,new TransitionTimeConfig_ViewModel(), new TransitionTimeConfig_ViewModel());
            InitializeComponent();
        }

        internal BrightnessWaveConfigWindow(BrightnessWaveConfig_VMSet configSet)
        {
            if(configSet != null)
                _brightnessWaveConfigSet = configSet;
            else
                _brightnessWaveConfigSet = new BrightnessWaveConfig_VMSet(new BrightnessConfig_ViewModel(), new LightListConfig_ViewModel(), new TransitionTimeConfig_ViewModel(), new TransitionTimeConfig_ViewModel());
            InitializeComponent();
            RefreshValuesInCard();
        }

        //internal ObservableCollection<IConfigListViewModel> LightListSource
        //{
        //    get { return BrightnessWaveConfigSet.LightList.Collection; }
        //    set {
        //        LightListConfig_ViewModel model = new LightListConfig_ViewModel(value);
        //        //RefreshValuesInCard();
        //    }
        //}

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
            RefreshBrightnessInCard();
            RefreshTransitionTimeInCard();
            RefreshIntervalTimeInCard();
            RefreshLightListInCard();
        }

        private void RefreshLightListInCard()
        {
            Resources["LightListSource"] = BrightnessWaveConfigSet.LightList.Collection;
        }

        private void RefreshBrightnessInCard()
        {
            BrightnessCard.BrightnessLevel = BrightnessWaveConfigSet.BrightnessLevel.BrightnessLevel;
        }

        private void RefreshTransitionTimeInCard()
        {
            TransitionTimeCard.TimeInTenthOfSecond = BrightnessWaveConfigSet.TransitionTime.TransitionTime;
        }

        private void RefreshIntervalTimeInCard()
        {
            IntervalTimeCard.TimeInTenthOfSecond = BrightnessWaveConfigSet.IntervalTime.TransitionTime;
        }

        private void BrightnessCard_BrightnessLevelChanged(object sender, RoutedEventArgs e)
        {
            BrightnessWaveConfigSet.BrightnessLevel = new BrightnessConfig_ViewModel(BrightnessCard.BrightnessLevel);
        }

        private void TransitionTimeCard_TransitionTimeChanged(object sender, RoutedEventArgs e)
        {
            BrightnessWaveConfigSet.TransitionTime = new TransitionTimeConfig_ViewModel(TransitionTimeCard.TimeInTenthOfSecond);
        }

        private void IntervalTimeCard_TransitionTimeChanged(object sender, RoutedEventArgs e)
        {
            BrightnessWaveConfigSet.IntervalTime = new TransitionTimeConfig_ViewModel(IntervalTimeCard.TimeInTenthOfSecond);
        }
    }
}

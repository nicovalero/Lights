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
    /// Interaction logic for TurnOnConfigWindow.xaml
    /// </summary>
    public partial class NanoleafEffectConfigWindow : Window
    {
        private NanoleafEffectConfig_VMSet _nanoleafEffectConfigSet;
        internal NanoleafEffectConfig_VMSet NanoleafEffectConfigSet { get { return _nanoleafEffectConfigSet; } set { _nanoleafEffectConfigSet = value; } }

        internal NanoleafEffectConfigWindow()
        {
            _nanoleafEffectConfigSet = new NanoleafEffectConfig_VMSet();
            InitializeComponent();
        }

        internal NanoleafEffectConfigWindow(NanoleafEffectConfig_VMSet configSet)
        {
            if(configSet != null)
                _nanoleafEffectConfigSet = configSet;
            else
                _nanoleafEffectConfigSet = new NanoleafEffectConfig_VMSet();
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
    }
}

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
    /// Interaction logic for TurnOffConfigWindow.xaml
    /// </summary>
    public partial class TurnOffConfigWindow : Window
    {
        private TurnOffConfig_VMSet _turnOffConfigSet;
        internal TurnOffConfig_VMSet TurnOffConfigSet { get { return _turnOffConfigSet; } set { _turnOffConfigSet = value; } }

        internal TurnOffConfigWindow()
        {
            _turnOffConfigSet = new TurnOffConfig_VMSet();
            InitializeComponent();
        }

        internal TurnOffConfigWindow(TurnOffConfig_VMSet configSet)
        {
            if(configSet != null)
                _turnOffConfigSet = configSet;
            else
                _turnOffConfigSet = new TurnOffConfig_VMSet();
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

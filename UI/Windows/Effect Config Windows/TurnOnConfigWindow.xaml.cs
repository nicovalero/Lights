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
    public partial class TurnOnConfigWindow : Window
    {
        private TurnOnConfig_VMSet _turnOnConfigSet;
        internal TurnOnConfig_VMSet TurnOnConfigSet { get { return _turnOnConfigSet; } set { _turnOnConfigSet = value; } }

        internal TurnOnConfigWindow()
        {
            _turnOnConfigSet = new TurnOnConfig_VMSet();
            InitializeComponent();
        }

        internal TurnOnConfigWindow(TurnOnConfig_VMSet configSet)
        {
            if(configSet != null)
                _turnOnConfigSet = configSet;
            else
                _turnOnConfigSet = new TurnOnConfig_VMSet();
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

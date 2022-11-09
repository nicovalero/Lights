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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Xceed.Wpf.Toolkit;

namespace UI.User_Controls.EffectConfigCards
{
    /// <summary>
    /// Interaction logic for BrightnessRangeConfigCard.xaml
    /// </summary>
    public partial class BrightnessSingleValueCard : UserControl
    {
        private const byte DEFAULTBRIGHTNESS = 0;
        private byte _brightnessLevel;
        public byte BrightnessLevel
        {
            get { return _brightnessLevel; }
            set
            {
                _brightnessLevel = value; slider.Value = _brightnessLevel;
            }
        }

        public BrightnessSingleValueCard()
        {
            InitializeComponent();
            BrightnessLevel = DEFAULTBRIGHTNESS;
        }

        public BrightnessSingleValueCard(byte higherBrightnessLevel, byte lowerBrightnessLevel)
        {
            InitializeComponent();
            BrightnessLevel = higherBrightnessLevel;
        }

        private void slider_ValueChanged(object sender, RoutedEventArgs e)
        {
            double value = ((Slider)sender).Value;
            try
            {
                byte valueByte = (byte)value;
                BrightnessLevel = valueByte;
            }
            catch
            {
                BrightnessLevel = DEFAULTBRIGHTNESS;
            }
            finally
            {
                if (BrightnessLevelChanged != null)
                    BrightnessLevelChanged(this, e);
            }
        }

        public event RoutedEventHandler BrightnessLevelChanged;
    }
}

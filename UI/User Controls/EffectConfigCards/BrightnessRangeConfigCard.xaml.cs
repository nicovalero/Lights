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
    public partial class BrightnessRangeConfigCard : UserControl
    {
        private const byte MAXBRIGHTNESS = 255;
        private const byte MINBRIGHTNESS = 0;
        private byte _higherBrightnessLevel;
        private byte _lowerBrightnessLevel;
        public byte HigherBrightnessLevel { get { return _higherBrightnessLevel; } set { _higherBrightnessLevel = value; slider.HigherValue = _higherBrightnessLevel; } }
        public byte LowerBrightnessLevel { get { return _lowerBrightnessLevel; } set { _lowerBrightnessLevel = value; slider.LowerValue = _lowerBrightnessLevel; } }
        public BrightnessRangeConfigCard()
        {
            InitializeComponent();
            HigherBrightnessLevel = MAXBRIGHTNESS;
            LowerBrightnessLevel = MINBRIGHTNESS;
        }

        public BrightnessRangeConfigCard(byte higherBrightnessLevel, byte lowerBrightnessLevel)
        {
            InitializeComponent();
            HigherBrightnessLevel = higherBrightnessLevel;
            LowerBrightnessLevel = lowerBrightnessLevel;
        }

        private void slider_LowerValueChanged(object sender, RoutedEventArgs e)
        {
            double value = ((RangeSlider)sender).LowerValue;
            try
            {
                byte valueByte = (byte)value;
                LowerBrightnessLevel = valueByte;
            }
            catch
            {
                LowerBrightnessLevel = byte.MinValue;
            }
            finally
            {
                if (LowerBrightnessLevelChanged != null)
                    LowerBrightnessLevelChanged(this, e);
            }            
        }

        private void slider_HigherValueChanged(object sender, RoutedEventArgs e)
        {
            double value = ((RangeSlider)sender).HigherValue;
            try
            {
                byte valueByte = (byte)value;
                HigherBrightnessLevel = valueByte;
            }
            catch
            {
                HigherBrightnessLevel = byte.MaxValue;
            }
            finally
            {
                if (HigherBrightnessLevelChanged != null)
                    HigherBrightnessLevelChanged(this, e);
            }
        }

        public event RoutedEventHandler LowerBrightnessLevelChanged;
        public event RoutedEventHandler HigherBrightnessLevelChanged;
    }
}

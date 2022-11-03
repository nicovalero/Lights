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

namespace UI.User_Controls.EffectConfigCards
{
    /// <summary>
    /// Interaction logic for BrightnessConfigCard.xaml
    /// </summary>
    public partial class BrightnessRangeConfigCard : UserControl
    {
        private const byte MAXBRIGHTNESS = 255;
        private byte _brightnessLevel;
        public byte BrightnessLevel { get { return _brightnessLevel; } set { _brightnessLevel = value; /*colorCanvas.SelectedColor = _color; */} } 
        public BrightnessRangeConfigCard()
        {
            _brightnessLevel = MAXBRIGHTNESS;
            InitializeComponent();
        }

        private void ColorCanvas_SelectedColorChanged(object sender, RoutedPropertyChangedEventArgs<byte> e)
        {
            _brightnessLevel = e.NewValue;

            if(SelectedLevelChanged != null)
                SelectedLevelChanged(this, e);
        }

        public event RoutedEventHandler SelectedLevelChanged;
    }
}

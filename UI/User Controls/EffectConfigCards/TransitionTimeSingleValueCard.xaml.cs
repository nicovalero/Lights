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
    public partial class TransitionTimeSingleValueCard : UserControl
    {
        private const uint DEFAULTTIME = 0;
        private uint _timeInMiliseconds;
        public uint TimeInMiliseconds
        {
            get { return _timeInMiliseconds; }
            set
            {
                _timeInMiliseconds = value; slider.Value = _timeInMiliseconds;
            }
        }

        public TransitionTimeSingleValueCard()
        {
            InitializeComponent();
            TimeInMiliseconds = DEFAULTTIME;
        }

        public TransitionTimeSingleValueCard(uint timeInMiliseconds)
        {
            InitializeComponent();
            TimeInMiliseconds = timeInMiliseconds;
        }

        private void slider_ValueChanged(object sender, RoutedEventArgs e)
        {
            double value = ((Slider)sender).Value;
            try
            {
                uint valueUint = (uint)value;
                TimeInMiliseconds = valueUint;
            }
            catch
            {
                TimeInMiliseconds = DEFAULTTIME;
            }
            finally
            {
                if (TransitionTimeChanged != null)
                    TransitionTimeChanged(this, e);
            }
        }

        public event RoutedEventHandler TransitionTimeChanged;
    }
}

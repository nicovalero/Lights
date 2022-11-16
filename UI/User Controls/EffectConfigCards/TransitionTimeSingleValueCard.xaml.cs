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
    /// Interaction logic for TransitionTimeSingleValueCard.xaml
    /// </summary>
    public partial class TransitionTimeSingleValueCard : UserControl
    {
        private const uint DEFAULTTIME = 0;
        private uint _timeInTenthOfSecond;
        public uint TimeInTenthOfSecond
        {
            get { return _timeInTenthOfSecond; }
            set
            {
                _timeInTenthOfSecond = value; slider.Value = _timeInTenthOfSecond;
            }
        }

        public TransitionTimeSingleValueCard()
        {
            InitializeComponent();
            TimeInTenthOfSecond = DEFAULTTIME;
        }

        public TransitionTimeSingleValueCard(uint timeInTenthOfSecond)
        {
            InitializeComponent();
            TimeInTenthOfSecond = timeInTenthOfSecond;
        }

        private void slider_ValueChanged(object sender, RoutedEventArgs e)
        {
            double value = ((Slider)sender).Value;
            UpdateTransitionTimeInSecondsLabel(value);
            try
            {
                uint valueUint = (uint)value;
                TimeInTenthOfSecond = valueUint;
            }
            catch
            {
                TimeInTenthOfSecond = DEFAULTTIME;
            }
            finally
            {
                if (TransitionTimeChanged != null)
                    TransitionTimeChanged(this, e);
            }
        }

        private void UpdateTransitionTimeInSecondsLabel(double value)
        {
            TransitionTimeInSecondsLabel.Content = value / 10.0;
        }

        public event RoutedEventHandler TransitionTimeChanged;
    }
}

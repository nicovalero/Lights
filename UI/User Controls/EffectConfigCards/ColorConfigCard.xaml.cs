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
    /// Interaction logic for ColorConfigCard.xaml
    /// </summary>
    public partial class ColorConfigCard : UserControl
    {
        private Color? _color;
        public Color? SelectedColor { get { return _color; } set { _color = value; colorCanvas.SelectedColor = _color; } } 
        public ColorConfigCard()
        {
            _color = null;
            InitializeComponent();
        }

        private void ColorCanvas_SelectedColorChanged(object sender, RoutedPropertyChangedEventArgs<Color?> e)
        {
            _color = e.NewValue;

            if(SelectedColorChanged != null)
                SelectedColorChanged(this, e);
        }

        public event RoutedEventHandler SelectedColorChanged;
    }
}

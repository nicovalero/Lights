using MIDI.Models.Structs;
using PhilipsHue.Actions.Interfaces;
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
using UI.Models.Structs;

namespace UI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        MainWindow_ViewController _mainWindow_Controller;
        public MainWindow()
        {
            _mainWindow_Controller = MainWindow_ViewController.Singleton();
            //RefreshLinkList();
            InitializeComponent();
        }

        private void RefreshLinkList()
        {
            Resources["MidiEffectLinks"] = _mainWindow_Controller.GetLinks();
            //List<MidiEffectLink> list = new List<MidiEffectLink>();

            //for (int i = 0; i <= 128; i++)
            //{
            //    list.Add(new MidiEffectLink((byte)0, (byte)127, (byte)i, (i%3 == 0 ? "Color change" : (i%3 == 1 ? "Flash" : "Fade"))));
            //}

            //Resources["MidiEffectLinks"] = list;
        }

        private void ConnectBridges()
        {
            _mainWindow_Controller.ConnectBridges();
        }

        private void ConnectBridgesButton_Click(object sender, RoutedEventArgs e)
        {
            ConnectBridges();
            RefreshLinkList();
        }
    }
}

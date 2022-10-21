using PhilipsHue.Models.Interfaces;
using System.Collections;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Input;
using UI.User_Controls;

namespace UI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly MainWindow_ViewController _mainWindow_Controller;
        public MainWindow()
        {
            _mainWindow_Controller = MainWindow_ViewController.Singleton();
            InitializeLists();
            InitializeComponent();
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if(e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }
        }

        private void ConnectBridges()
        {
            _mainWindow_Controller.ConnectBridges();
        }

        private void InitializeLists()
        {
            RefreshEffectList();
            RefreshAvailableMidiChannelList();
            RefreshAvailableMidiNoteList();
            RefreshAvailableMidiVelocityList();
            RefreshAvailableHueLights();
        }

        private void RefreshLinkList()
        {
            Resources["MidiEffectLinks"] = _mainWindow_Controller.GetLinks();
        }

        private void RefreshEffectList()
        {
            Resources["HueEffectList"] = _mainWindow_Controller.GetHueEffectList();
        }

        private void RefreshAvailableMidiChannelList()
        {
            Resources["AvailableMidiChannelList"] = _mainWindow_Controller.GetAvailableChannelList();
        }

        private void RefreshAvailableMidiNoteList()
        {
            Resources["AvailableMidiNoteList"] = _mainWindow_Controller.GetAvailableMidiNoteList();
        }

        private void RefreshAvailableMidiVelocityList()
        {
            Resources["AvailableMidiVelocityList"] = _mainWindow_Controller.GetAvailableMidiVelocityList();
        }

        private void RefreshAvailableHueLights()
        {
            var list = _mainWindow_Controller.GetAvailableHueLightsList();
            Resources["AvailableHueLights"] = _mainWindow_Controller.GetAvailableHueLightsList();
            Resources["NumberOfAvailableHueLights"] = list.Count;
        }

        private void ConnectBridgesButton_Click(object sender, RoutedEventArgs e)
        {
            ConnectBridges();
            RefreshLinkList();
            RefreshAvailableHueLights();
        }

        private void LinkButton_Click(object sender, RoutedEventArgs e)
        {
            IList selectedLights = HueLightsList.SelectedItems;
            //object selectedEffect = HueEffectList.SelectedItem;
            //object selectedChannel = HueChannelList.SelectedItem;
            //object selectedNote = HueMidiNoteList.SelectedItem;
            //object selectedVelocity = HueMidiVelocityList.SelectedItem;

            //_mainWindow_Controller.CreateLink(selectedLights, selectedEffect, selectedChannel, selectedNote, selectedVelocity);

            //RefreshLinkList();
        }

        private void StartListeningButton_Click(object sender, RoutedEventArgs e)
        {
            _mainWindow_Controller.StartListening();
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            _mainWindow_Controller.SaveLinksToFile();
        }

        private void LoadButton_Click(object sender, RoutedEventArgs e)
        {
            if (_mainWindow_Controller.LoadLinksFromFile())
                RefreshLinkList();
        }

        private void ControlMenuButton_Click(object sender, RoutedEventArgs e)
        {
            LinkManagementSection.Visibility = Visibility.Hidden;
            LinkManagementMenuButton.Style = (Style)Application.Current.Resources["menuButton"];

            ControlSection.Visibility = Visibility.Visible;
            ControlMenuButton.Style = (Style)Application.Current.Resources["menuButtonActive"];
        }

        private void LinkManagementMenuButton_Click(object sender, RoutedEventArgs e)
        {
            LinkManagementSection.Visibility = Visibility.Visible;
            LinkManagementMenuButton.Style = (Style)Application.Current.Resources["menuButtonActive"];

            ControlSection.Visibility = Visibility.Hidden;
            ControlMenuButton.Style = (Style) Application.Current.Resources["menuButton"];
        }
    }
}

using Control.Controllers;
using PhilipsHue.EffectConfig.Creators.Interfaces;
using PhilipsHue.Models.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using UI.Models.Interfaces;
using UI.Models.Structs;
using UI.Models.ViewModel_Config_Sets;
using UI.Models.ViewModel_Config_Sets.Classes;
using UI.Models.ViewModel_Config_Sets.Interfaces;
using UI.User_Controls;

namespace UI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly MainWindow_ViewController _mainWindow_Controller;
        private IConfigVMSet _currentEffectConfiguration;
        internal IConfigVMSet CurrentEffectConfiguration => _currentEffectConfiguration;
        public MainWindow()
        {
            _mainWindow_Controller = MainWindow_ViewController.Singleton();
            InitializeLists();
            InitializeComponent();
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }
        }

        private void ConnectBridges()
        {
            _mainWindow_Controller.ConnectBridges();
        }

        private void RefreshHueBridgeCount()
        {
            Resources["HueBridgeCount"] = _mainWindow_Controller.GetHueBridgeCount();
        }

        private void InitializeLists()
        {
            RefreshEffectList();
            RefreshAvailableMidiChannelList();
            RefreshAvailableMidiNoteList();
            RefreshAvailableMidiVelocityList();
            RefreshAvailableHueLights();
            RefreshMIDIListeningStatus();
        }

        private void RefreshLinkList()
        {
            Resources["MidiEffectLinks"] = _mainWindow_Controller.GetLinks();
        }

        private void RefreshEffectList()
        {
            Resources["HueEffectList"] = _mainWindow_Controller.GetHueEffectCardConfigList();
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

        private void RefreshMIDIListeningStatus()
        {
            Resources["MIDIListening"] = _mainWindow_Controller.GetMidiListeningStatusString();
        }

        private void RefreshAvailableHueLights()
        {
            var list = _mainWindow_Controller.GetAvailableHueLightsList();
            if (list != null)
            {
                Resources["NumberOfAvailableHueLights"] = list.Count;
                if (list.Count > 0)
                {
                    Resources["AvailableHueLights"] = list;
                    Resources["AvailableHueLightsConfigCard"] = _mainWindow_Controller.GetAvailableHueLights_CardConfigList();
                }
            }
        }

        private void ConnectBridgesButton_Click(object sender, RoutedEventArgs e)
        {
            ConnectBridges();
            RefreshLinkList();
            RefreshAvailableHueLights();
            RefreshHueBridgeCount();
        }

        private void LinkButton_Click(object sender, RoutedEventArgs e)
        {
            IList selectedLights = GetSelectedLightsCollection();

            IConfigListViewModel selectedEffect = (CardConfigList_ViewModel)LinkEffectList.SelectedItem;
            IConfigListViewModel selectedChannel = (SimpleConfigList_ViewModel)LinkChannelList.SelectedItem;
            IConfigListViewModel selectedNote = (SimpleConfigList_ViewModel)LinkNoteList.SelectedItem;
            IConfigListViewModel selectedVelocity = (SimpleConfigList_ViewModel)LinkVelocityList.SelectedItem;

            _mainWindow_Controller.CreateLink(selectedLights, selectedEffect, selectedChannel, selectedNote, selectedVelocity, CurrentEffectConfiguration);

            RefreshLinkList();
        }

        private void StartListeningButton_Click(object sender, RoutedEventArgs e)
        {
            _mainWindow_Controller.StartListening();
            RefreshMIDIListeningStatus();
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

            DeviceStatusSection.Visibility = Visibility.Hidden;
            DeviceStatusMenuButton.Style = (Style)Application.Current.Resources["menuButton"];
        }

        private void LinkManagementMenuButton_Click(object sender, RoutedEventArgs e)
        {
            LinkManagementSection.Visibility = Visibility.Visible;
            LinkManagementMenuButton.Style = (Style)Application.Current.Resources["menuButtonActive"];

            ControlSection.Visibility = Visibility.Hidden;
            ControlMenuButton.Style = (Style)Application.Current.Resources["menuButton"];

            DeviceStatusSection.Visibility = Visibility.Hidden;
            DeviceStatusMenuButton.Style = (Style)Application.Current.Resources["menuButton"];
        }

        private void DeviceStatusMenuButton_Click(object sender, RoutedEventArgs e)
        {
            LinkManagementSection.Visibility = Visibility.Hidden;
            LinkManagementMenuButton.Style = (Style)Application.Current.Resources["menuButton"];

            ControlSection.Visibility = Visibility.Hidden;
            ControlMenuButton.Style = (Style)Application.Current.Resources["menuButton"];

            DeviceStatusSection.Visibility = Visibility.Visible;
            DeviceStatusMenuButton.Style = (Style)Application.Current.Resources["menuButtonActive"];
        }

        private void CloseAppButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void MinimizeAppButton_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void EffectConfiguration_Click(object sender, RoutedEventArgs e)
        {
            if (LinkEffectList.SelectedItem != null)
            {
                Window window = null;
                try
                {
                    List<IConfigListViewModel> list = GetSelectedLightsCollection();

                    window = _mainWindow_Controller.GetConfigWindow((CardConfigList_ViewModel)LinkEffectList.SelectedItem, list);
                }
                finally
                {
                    if (window != null)
                    {
                        window.Closed += ConfigWindow_Closed;
                        window.ShowDialog();
                    }
                }
            }
        }

        private void ConfigWindow_Closed(object sender, System.EventArgs e)
        {
            IConfigVMSet newConfig;
            switch (sender)
            {
                case ColorChangeConfigWindow w:
                    newConfig = w.ColorChangeConfigSet;
                    break;
                case FlashConfigWindow w:
                    newConfig = w.FlashConfigSet;
                    break;
                case FadeInConfigWindow w:
                    newConfig = w.FadeInConfigSet;
                    break;
                case FadeOutConfigWindow w:
                    newConfig = w.FadeOutConfigSet;
                    break;
                case BrightnessWaveConfigWindow w:
                    newConfig = w.BrightnessWaveConfigSet;
                    break;
                case ColorWaveConfigWindow w:
                    newConfig = w.ColorWaveConfigSet;
                    break;
                default:
                    newConfig = null;
                    break;
            }

            _currentEffectConfiguration = newConfig;
        }

        private List<IConfigListViewModel> GetSelectedLightsCollection()
        {
            List<IConfigListViewModel> selectedLights = new List<IConfigListViewModel>();
            IList items = LinkLightList.SelectedItems;
            var collection = items.Cast<CardConfigList_ViewModel>();

            foreach (CardConfigList_ViewModel item in collection)
                selectedLights.Add(item);

            return selectedLights;
        }

        private void LinkManagement_LinkList_OnDeleteClick(object sender, RoutedEventArgs e)
        {
            bool success = false;
            if(e.Source is Button)
            {
                if(((Button)e.Source).DataContext != null)
                {
                    success = _mainWindow_Controller.DeleteLink(((Button)e.Source).DataContext);
                }                
            }

            if (success)
                RefreshLinkList();
        }
    }
}

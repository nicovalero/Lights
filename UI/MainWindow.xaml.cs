﻿using MIDI.Models.Structs;
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
            InitializeLists();
            InitializeComponent();
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

        private void ConnectBridgesButton_Click(object sender, RoutedEventArgs e)
        {
            ConnectBridges();
            RefreshLinkList();
        }
    }
}
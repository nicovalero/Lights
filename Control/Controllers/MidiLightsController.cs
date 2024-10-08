﻿using PhilipsHue.Controllers;
using PhilipsHue.Models.Classes;
using MIDI.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MIDI.Models.Structs;
using PhilipsHue.Actions.Interfaces;
using Windows.Devices.Midi;
using System.Threading;
using PhilipsHue.Actions.Classes;
using PhilipsHue.Effects.Classes;
using MIDI.Models.Class;
using PhilipsHue.Collections;
using PhilipsHue.Effects.Interfaces;
using PhilipsHue.Models.Interfaces;
using Newtonsoft.Json;
using DataStorage.Models;
using System.Collections;
using Windows.UI.Xaml.Shapes;
using Windows.Devices.Enumeration;
using PhilipsHue.EffectConfig.Creators.Interfaces;
using System.Diagnostics;

namespace Control.Controllers
{
    public class MidiLightsController
    {
        private readonly ActionController _actionController;
        private readonly MidiController _midiController;
        private readonly StorageController _storageController;
        private static readonly MidiLightsController _midiLightsController = new MidiLightsController();
        private readonly HueLightController _hueLightController;
        private static Dictionary<MidiMessageKeys, LightEffectAction> _messageActionLinks;

        private MidiLightsController()
        {
            _storageController = StorageController.Singleton();
            _actionController = ActionController.Singleton();
            _midiController = MidiController.Singleton();
            _messageActionLinks = new Dictionary<MidiMessageKeys, LightEffectAction>();
            _hueLightController = HueLightController.Singleton();
            _midiController.MessageEventHandler += MidiMessageReceived;
        }

        public static MidiLightsController Singleton()
        {
            return _midiLightsController;
        }

        public void MidiMessageReceived(MidiController sender, MidiMessageKeys args)
        {
            var stopw = Stopwatch.StartNew();
            ThreadPool.QueueUserWorkItem((state) => PerformLinkedAction(args));
            stopw.Stop();
            Console.WriteLine("Midi Message processed in " + stopw.ElapsedMilliseconds);
        }

        public bool CreateLink(MidiChannel channel, MidiNote note, MidiVelocity velocity, List<HueLight> lights, LightEffect effect, IEffectConfigSet config = null)
        {
            MidiMessageKeys keys = new MidiMessageKeys(channel, velocity, note);

            if (_messageActionLinks.ContainsKey(keys))
                return false;
            else
            {
                SingleLightEffectAction action = new SingleLightEffectAction(lights, effect, config);
                _messageActionLinks.Add(keys,action);
            }

            return true;
        }

        public bool RemoveLink(MidiMessageKeys keys)
        {
            if (!_messageActionLinks.ContainsKey(keys))
                return false;
            else
                _messageActionLinks.Remove(keys);

            return true;
        }

        public bool SaveLinksToFile()
        {
            HueLinkSaveObject saveObject = new HueLinkSaveObject(_messageActionLinks);
            return _storageController.SaveLinks(saveObject);
        }

        public bool ReadLinksFromFile()
        {
            HueLinkSaveObject links = _storageController.ReadLinks();

            if (links != null)
            {
                _messageActionLinks.Clear();
                foreach (KeyValuePair<MidiMessageKeys, LightEffectAction> link in links.Links)
                {
                    _messageActionLinks.Add(link.Key, link.Value);
                }
            }
            else
                return false;

            return true;
        }

        public bool PerformLinkedAction(MidiMessageKeys keys)
        {
            if (!_messageActionLinks.ContainsKey(keys))
                return false;
            else
            {
                LightEffectAction action = _messageActionLinks[keys];
                _actionController.PerformAction(action);
            }

            return true;
        }

        public void StartMidiController()
        {
            _midiController.Start();
        }

        public void StopMidiController()
        {
            _midiController.Stop();
        }

        public string MidiListeningString()
        {
            DeviceWatcherStatus status = _midiController.ListeningStatus();
            string statusString = "";
            switch (status)
            {
                case DeviceWatcherStatus.Started:
                    statusString = "Started";
                    break;
                case DeviceWatcherStatus.Stopped:
                    statusString = "Stopped";
                    break;
                case DeviceWatcherStatus.Stopping:
                    statusString = "Stopping";
                    break;
                case DeviceWatcherStatus.EnumerationCompleted:
                    statusString = "Enumeration Completed";
                    break;
                case DeviceWatcherStatus.Aborted:
                    statusString = "Aborted";
                    break;
                default:
                    statusString = "Unknown";
                    break;
            }

            return statusString;
        }

        public void ConnectBridges()
        {
            _hueLightController.InitializeBridges();
        }

        public int GetHueBridgeCount()
        {
            return _hueLightController.GetBridgeCount();
        }

        public Dictionary<MidiMessageKeys, LightEffectAction> GetMessageActionLinks()
        {
            return _messageActionLinks;
        }

        public List<MidiNote> GetAllMidiNotes()
        {
            return MidiNoteCollection.GetAllNotesList();
        }

        public List<MidiChannel> GetAvailableChannels()
        {
            return MidiChannelCollection.GetAllChannelList();
        }

        public List<MidiVelocity> GetAvailableVelocities()
        {
            return MidiVelocityCollection.GetAllVelocityList();
        }

        public List<LightEffect> GetAllHueEffects()
        {
            return HueLightEffectCollection.GetAllEffectList();
        }

        public List<HueLight> GetAllAvailableHueLights()
        {
            return _hueLightController.GetAllLightsList();
        }
    }
}

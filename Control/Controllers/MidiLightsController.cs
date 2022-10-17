using PhilipsHue.Controllers;
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

namespace Control.Controllers
{
    public class MidiLightsController
    {
        private readonly ActionController _actionController;
        private readonly MidiController _midiController;
        private static readonly MidiLightsController _midiLightsController = new MidiLightsController();
        private readonly HueLightController _hueLightController;
        private static Dictionary<MidiMessageKeys, LightEffectAction> _messageActionLinks;

        private void TestingData()
        {
            List<string> lights = new List<string>();
            lights.Add("00:17:88:01:04:53:45:40-0b");
            lights.Add("00:17:88:01:04:3e:0c:1c-0b");
            lights.Add("00:17:88:01:04:17:3b:a0-0b");
            lights.Add("00:17:88:01:04:87:fe:56-0b");
            lights.Add("00:17:88:01:03:8d:35:a1-0b");
            lights.Add("00:17:88:01:06:ee:4f:74-0b");

            SingleLightEffectAction action;

            MidiMessageKeys keys;

            for (int i = 60; i < 70; i++)
            {
                action = new SingleLightEffectAction(lights, ColorChange.Singleton(), (i % 2 == 0 ? (ushort)30000 : (ushort)60000));

                keys = new MidiMessageKeys();
                keys.Channel = new MidiChannel(0);
                keys.Velocity = 127;
                keys.Note = MidiNoteCollection.GetNote((byte)i).Value;
                keys.Port = null;

                LinkMessageWithAction(keys, action);
            }
        }

        private MidiLightsController()
        {
            _actionController = ActionController.Singleton();
            _midiController = MidiController.Singleton();
            _messageActionLinks = new Dictionary<MidiMessageKeys, LightEffectAction>();
            _hueLightController = HueLightController.Singleton();
            _midiController.MessageEventHandler += MidiMessageReceived;

            TestingData();
        }

        public static MidiLightsController Singleton()
        {
            return _midiLightsController;
        }

        public void MidiMessageReceived(MidiController sender, MidiMessageKeys args)
        {
            PerformLinkedAction(args);
        }

        public bool LinkMessageWithAction(MidiMessageKeys keys, LightEffectAction action)
        {
            if (_messageActionLinks.ContainsKey(keys))
                return false;
            else
                _messageActionLinks.Add(keys, action);

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

        public void ConnectBridges()
        {
            _hueLightController.InitializeBridges();
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

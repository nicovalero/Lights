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

namespace Control.Controllers
{
    internal class MidiLightsController
    {
        private readonly ActionController _actionController;
        private readonly MidiController _midiController;
        private static readonly MidiLightsController _midiLightsController = new MidiLightsController();
        private static Dictionary<MidiMessageKeys, LightEffectAction> _messageActionLinks;

        private MidiLightsController()
        {
            _actionController = ActionController.Singleton();
            _midiController = MidiController.Singleton();
            _messageActionLinks = new Dictionary<MidiMessageKeys, LightEffectAction>();
            _midiController.MessageEventHandler += MidiMessageReceived;
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
            //Test
            _midiController.Start();
        }

        public void StopMidiController()
        {
            _midiController.Stop();
        }
    }
}

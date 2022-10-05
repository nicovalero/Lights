using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Devices.Midi;
using PhilipsHue.Actions.Interfaces;

namespace MIDI.Controllers
{
    internal class MidiController
    {
        private static readonly MidiController _controller = new MidiController();
        private static Dictionary<IMidiMessage, LightEffectAction> _messageActionLinks;

        private MidiController() {
            _messageActionLinks = new Dictionary<IMidiMessage, LightEffectAction>();
        }

        public static MidiController Singleton()
        {
            return _controller;
        }

        public bool LinkMessageWithAction(IMidiMessage message, LightEffectAction action)
        {
            if (_messageActionLinks.ContainsKey(message))
                return false;
            else
                _messageActionLinks.Add(message, action);

            return true;
        }

        public bool RemoveLink(IMidiMessage message)
        {
            if (!_messageActionLinks.ContainsKey(message))
                return false;
            else
                _messageActionLinks.Remove(message);

            return true;
        }

        public bool PerformLinkedAction(IMidiMessage message)
        {
            //Need to review this
            //Dictionary will never contain key unless I override it and analize the specific properties I need.
            //It is never the same object unfortunately
            if (!_messageActionLinks.ContainsKey(message))
                return false;
            else
            {
                LightEffectAction action = _messageActionLinks[message];
                action.Perform();
            }

            return true;
        }
    }
}

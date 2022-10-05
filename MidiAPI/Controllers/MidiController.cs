using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Devices.Midi;
using PhilipsHueAPI.Interfaces;

namespace MIDI.Controllers
{
    internal class MidiController
    {
        private static readonly MidiController _controller = new MidiController();
        private Dictionary<IMidiMessage, LightEffect> dictionary;

        private MidiController() {
                    
        }
        public static MidiController Singleton()
        {
            return _controller;
        }
    }
}

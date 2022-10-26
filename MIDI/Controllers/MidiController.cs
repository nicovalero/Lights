using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Devices.Midi;
using PhilipsHue.Actions.Interfaces;
using MIDI.Models.Structs;
using System.Runtime.InteropServices;
using Windows.Foundation;
using Windows.Devices.Enumeration;

namespace MIDI.Controllers
{
    public class MidiController
    {
        private static readonly MidiController _controller = new MidiController();
        private static readonly MidiDeviceWatcher _deviceWatcher = new MidiDeviceWatcher(MidiInPort.GetDeviceSelector());

        private MidiController() { }

        public static MidiController Singleton()
        {
            return _controller;
        }

        public event TypedEventHandler<MidiController, MidiMessageKeys> MessageEventHandler;

        public void MessageReceived(MidiMessageKeys keys)
        {
            MessageEventHandler(this, keys);
        }

        public void Start()
        {
            _deviceWatcher.Start();
        }
        public void Stop()
        {
            _deviceWatcher.Stop();
        }

        public DeviceWatcherStatus ListeningStatus()
        {
            return _deviceWatcher.GetStatus();
        }
    }
}

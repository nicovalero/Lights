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
        private readonly MidiDeviceWatcher _deviceWatcher;
        public event TypedEventHandler<MidiController, MidiMessageKeys> MessageEventHandler;

        public MidiController() {
            _deviceWatcher = new MidiDeviceWatcher(MidiInPort.GetDeviceSelector());
            _deviceWatcher.MessageReceivedHandler += MessageReceived;
        }

        internal void MessageReceived(MidiDeviceWatcher sender, MidiMessageKeys keys)
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

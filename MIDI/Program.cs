using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Windows.Devices.Midi;

namespace MIDI
{
    internal class Program
    {

        /// <summary>
        /// Collection of active MidiInPorts
        /// </summary>

        static ManualResetEvent _quitEvent = new ManualResetEvent(false);

        static void Main(string[] args)
        {
            List<MidiInPort> midiInPorts;
            MidiDeviceWatcher midiInDeviceWatcher;

            // Initialize the list of active MIDI input devices
            midiInPorts = new List<MidiInPort>();

            // Set up the MIDI input device watcher
            midiInDeviceWatcher = new MidiDeviceWatcher(MidiInPort.GetDeviceSelector());

            // Start watching for devices
            midiInDeviceWatcher.Start();

            Console.CancelKeyPress += (sender, eArgs) => {
                _quitEvent.Set();
                eArgs.Cancel = true;
            };

            _quitEvent.WaitOne();
        }
    }
}

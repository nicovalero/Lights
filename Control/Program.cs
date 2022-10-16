using Control.Controllers;
using MIDI.Controllers;
using MIDI.Models.Structs;
using PhilipsHue.Actions.Classes;
using PhilipsHue.Effects.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Control
{
    internal class Program
    {
        static ManualResetEvent _quitEvent = new ManualResetEvent(false);
        static void Main(string[] args)
        {
            MidiLightsController midiLightsController = MidiLightsController.Singleton();
            midiLightsController.ConnectBridges();

            List<string> lights = new List<string>();
            lights.Add("00:17:88:01:04:53:45:40-0b");
            lights.Add("00:17:88:01:04:17:3b:a0-0b");
            lights.Add("00:17:88:01:04:87:fe:56-0b");
            lights.Add("00:17:88:01:04:3e:0c:1c-0b");
            lights.Add("00:17:88:01:03:8d:35:a1-0b");
            lights.Add("00:17:88:01:06:ee:4f:74-0b");

            SingleLightEffectAction action;

            MidiMessageKeys keys;

            for (int i = 0; i < 128; i++)
            {
                action = new SingleLightEffectAction(lights, ColorChange.Singleton(), (i % 2 == 0 ? (ushort)30000 : (ushort) 60000));

                keys = new MidiMessageKeys();
                keys.Channel = new MidiChannel(0);
                keys.Velocity = 127;
                keys.Note = MidiNoteCollection.GetNote((byte)i).Value;
                keys.Port = null;

                midiLightsController.LinkMessageWithAction(keys, action);
            }

            midiLightsController.StartMidiController();

            Console.CancelKeyPress += (sender, eArgs) => {
                _quitEvent.Set();
                eArgs.Cancel = true;
            };

            _quitEvent.WaitOne();
        }
    }
}

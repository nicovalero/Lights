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

            MidiMessageKeys keys = new MidiMessageKeys();
            keys.Channel = 1;
            keys.Velocity = 127;
            keys.Note = 78;

            MidiMessageKeys keys2 = new MidiMessageKeys();
            keys2.Channel = 1;
            keys2.Velocity = 127;
            keys2.Note = 78;

            List<string> lights = new List<string>();
            lights.Add("3");

            SingleLightEffectAction action = new SingleLightEffectAction(lights, ColorChange.Singleton(), (ushort)30000);

            midiLightsController.LinkMessageWithAction(keys, action);
            //midiLightsController.PerformLinkedAction(keys2);

            midiLightsController.StartMidiController();

            Console.CancelKeyPress += (sender, eArgs) => {
                _quitEvent.Set();
                eArgs.Cancel = true;
            };

            _quitEvent.WaitOne();
        }
    }
}

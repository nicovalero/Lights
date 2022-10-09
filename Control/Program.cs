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

            List<string> lights = new List<string>();
            lights.Add("1");
            lights.Add("2");
            lights.Add("3");
            lights.Add("4");
            lights.Add("6");
            lights.Add("8");

            SingleLightEffectAction action;

            MidiMessageKeys keys;

            for (int i = 0; i < 128; i++)
            {
                action = new SingleLightEffectAction(lights, Flash.Singleton(), (ushort)30000);

                keys = new MidiMessageKeys();
                keys.Channel = 0;
                keys.Velocity = 127;
                keys.Note = (byte)i;
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

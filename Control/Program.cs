using Control.Controllers;
using MIDI.Controllers;
using MIDI.Models.Structs;
using PhilipsHue.Actions.Classes;
using PhilipsHue.Effects.Classes;
using PhilipsHue.Models.Interfaces;
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

            List<HueLight> lights = midiLightsController.GetAllAvailableHueLights();
            HueLight light = lights.FirstOrDefault(x => x.name == "lightstrip");

            if(light != null)
                lights.Remove(light);

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

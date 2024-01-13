using Control.Classes;
using Control.Models.Interfaces;
using MIDI.Models.Structs;
using PhilipsHue.Actions.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Control.Parsers.DeviceParsers
{
    internal static class HueDevicesParser
    {
        public static Dictionary<MidiMessageKeys, IControlledLightEffectAction> TransformLinksToLightEffectActionLinks(Dictionary<MidiMessageKeys, LightEffectAction> originalDictionary)
        {
            var newDictionary = new Dictionary<MidiMessageKeys, IControlledLightEffectAction>();

            foreach(var originalPair in originalDictionary)
            {
                newDictionary.Add(originalPair.Key, new PhilipsHueControlledLightEffectAction(originalPair.Value));
            }

            return newDictionary;
        }
    }
}

using Control.Models.Interfaces;
using MIDI.Models.Structs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Control.Models.Structs
{
    public struct MidiMessageViewLightsEffectConfig
    {
        public List<IViewLight> ViewLights { get; set; }
        public MidiMessageKeys MidiMessageKeys { get; set; }
        public IViewEffect ViewEffect { get; set; }
        public IViewEffectConfigSet ViewEffectConfigSet { get; set; }

        public MidiMessageViewLightsEffectConfig(List<IViewLight> viewLights, MidiMessageKeys midiMessageKeys, 
            IViewEffect viewEffect, IViewEffectConfigSet viewEffectConfigSet)
        {
            ViewLights = viewLights;
            MidiMessageKeys = midiMessageKeys;
            ViewEffect = viewEffect;
            ViewEffectConfigSet = viewEffectConfigSet;
        }
    }
}

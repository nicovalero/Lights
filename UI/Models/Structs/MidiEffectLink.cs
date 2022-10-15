using MIDI.Models.Structs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI.Models.Structs
{
    internal struct MidiEffectLink
    {
        public string Channel { get; set; }
        public string Velocity { get; set; }
        public string Note { get; set; }
        public string Effect { get; set; }

        public MidiEffectLink(byte channel, byte velocity, byte note, string effect)
        {
            Channel = channel.ToString();
            Velocity = velocity.ToString();
            Note = note.ToString();
            Effect = effect;
        }
    }
}

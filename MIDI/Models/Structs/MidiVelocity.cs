using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MIDI.Models.Structs
{
    public struct MidiVelocity
    {
        public byte Velocity { get; set; }
        public string Name { get; set; }

        public MidiVelocity(byte velocity)
        {
            Velocity = velocity;
            Name = velocity.ToString();
        }
        public static bool operator ==(MidiVelocity key1, MidiVelocity key2)
        {
            return (key1.Velocity == key2.Velocity);
        }

        public static bool operator !=(MidiVelocity key1, MidiVelocity key2)
        {
            return !(key1.Velocity == key2.Velocity);
        }
    }
}

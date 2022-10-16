using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MIDI.Models.Structs
{
    public struct MidiChannel
    {
        public byte Channel { get; set; }
        public string Name { get; set; }

        public MidiChannel(byte channel)
        {
            Channel = channel;
            Name = "Channel " + channel;
        }
        public static bool operator ==(MidiChannel key1, MidiChannel key2)
        {
            return (key1.Channel == key2.Channel);
        }

        public static bool operator !=(MidiChannel key1, MidiChannel key2)
        {
            return !(key1.Channel == key2.Channel);
        }
    }
}

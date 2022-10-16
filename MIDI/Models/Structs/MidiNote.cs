using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MIDI.Models.Structs
{
    public struct MidiNote
    {
        public byte Note { get; set; }
        public string Name { get; set; }

        public MidiNote(byte note, string name)
        {
            Note = note;
            Name = name;
        }
        public static bool operator ==(MidiNote key1, MidiNote key2)
        {
            return (key1.Note == key2.Note);
        }

        public static bool operator !=(MidiNote key1, MidiNote key2)
        {
            return !(key1.Note == key2.Note);
        }
    }
}

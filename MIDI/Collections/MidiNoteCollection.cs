using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MIDI.Models.Structs
{
    public static class MidiNoteCollection
    {
        private static Dictionary<byte, MidiNote> _notes;
        public static Dictionary<byte, MidiNote> Notes { get { return _notes; } }
        static MidiNoteCollection()
        {
            _notes = new Dictionary<byte, MidiNote>();
            FillDictionary();
        }

        private static void FillDictionary()
        {
            MidiNote note;
            string name;
            int n = -3;
            for (byte i=0; i <= 127; i++)
            {
                name = "";
                switch (i % 12)
                {
                    case 0:
                        n++;
                        name += "C";
                        break;
                    case 1:
                        name += "C#";
                        break;
                    case 2:
                        name += "D";
                        break;
                    case 3:
                        name += "D#";
                        break;
                    case 4:
                        name += "E";
                        break;
                    case 5:
                        name += "F";
                        break;
                    case 6:
                        name += "F#";
                        break;
                    case 7:
                        name += "G";
                        break;
                    case 8:
                        name += "G#";
                        break;
                    case 9:
                        name += "A";
                        break;
                    case 10:
                        name += "A#";
                        break;
                    case 11:
                        name += "B";
                        break;
                }
                name += n;
                note = new MidiNote(i, name);

                Notes.Add(i, note);
            }
        }

        public static MidiNote? GetNote(byte note)
        {
            if (Notes.ContainsKey(note))
                return Notes[note];
            else
                return null;
        }

        public static List<MidiNote> GetAllNotesList()
        {
            return Notes.Values.ToList();
        }

        public static bool Exists(byte note)
        {
            return Notes.ContainsKey(note);
        }
    }
}

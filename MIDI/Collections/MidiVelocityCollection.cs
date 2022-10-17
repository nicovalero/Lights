using MIDI.Models.Structs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MIDI.Models.Class
{
    public class MidiVelocityCollection
    {
        private static Dictionary<byte, MidiVelocity> _velocities;
        public static Dictionary<byte, MidiVelocity> Velocities { get { return _velocities; } }
        static MidiVelocityCollection()
        {
            _velocities = new Dictionary<byte, MidiVelocity>();
            FillDictionary();
        }

        private static void FillDictionary()
        {
            for (byte i = 0; i <= 127; i++)
            {
                Velocities.Add(i, new MidiVelocity(i));
            }
        }

        public static MidiVelocity? GetVelocity(byte channel)
        {
            if (Velocities.ContainsKey(channel))
                return Velocities[channel];
            else
                return null;
        }

        public static List<MidiVelocity> GetAllVelocityList()
        {
            return Velocities.Values.ToList();
        }
    }
}

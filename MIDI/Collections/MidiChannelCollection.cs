using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading.Tasks;

namespace MIDI.Models.Structs
{
    public static class MidiChannelCollection
    {
        private static Dictionary<byte, MidiChannel> _channels;
        public static Dictionary<byte, MidiChannel> Channels { get { return _channels; } }
        static MidiChannelCollection()
        {
            _channels = new Dictionary<byte, MidiChannel>();
            FillDictionary();
        }

        private static void FillDictionary()
        {
            for (byte i=0; i <= 16; i++)
            {
                Channels.Add(i, new MidiChannel(i));
            }
        }

        public static MidiChannel? GetChannel(byte channel)
        {
            if (Channels.ContainsKey(channel))
                return Channels[channel];
            else
                return null;
        }

        public static List<MidiChannel> GetAllChannelList()
        {
            return Channels.Values.ToList();
        }
    }
}

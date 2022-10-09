namespace MIDI.Models.Structs
{
    public struct MidiMessageKeys
    {
        public byte Channel;
        public byte Velocity;
        public byte Note;
        public string Port;

        public MidiMessageKeys(byte channel, byte velocity, byte note, string port)
        {
            Channel = channel;
            Velocity = velocity;
            Note = note;
            Port = port;
        }
        public static bool operator ==(MidiMessageKeys key1, MidiMessageKeys key2)
        {
            return (key1.Channel == key2.Channel && key1.Velocity == key2.Velocity && key1.Note == key2.Note/* && key1.Port == key2.Port*/);
        }

        public static bool operator !=(MidiMessageKeys key1, MidiMessageKeys key2)
        {
            return !(key1.Channel == key2.Channel && key1.Velocity == key2.Velocity && key1.Note == key2.Note/* && key1.Port == key2.Port*/);
        }
    }
}

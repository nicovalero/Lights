using MIDI.Models.Structs;
using PhilipsHue.Effects.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI.Models.Structs
{
    internal struct MidiEffectLink_ViewModel
    {
        private MidiChannel _channel;
        private byte _velocity;
        private MidiNote _note;
        private LightEffect _effect;
        public MidiChannel Channel { get { return _channel; } set { _channel = value; } }
        public string ChannelName { get { return _channel.Name; } }
        public byte Velocity { get { return _velocity; } set { _velocity = value; } }
        public MidiNote Note { get { return _note; } set { _note = value; } }
        public string NoteName { get { return _note.Name; } }
        public LightEffect Effect { get { return _effect; } set { _effect = value; } }
        public string EffectName { get { return _effect.Name; } }

        public MidiEffectLink_ViewModel(MidiChannel channel, byte velocity, MidiNote note, LightEffect effect)
        {
            _channel = channel;
            _velocity = velocity;
            _note = note;
            _effect = effect;
        }
    }
}

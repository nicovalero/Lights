﻿using MIDI.Models.Structs;
using PhilipsHue.EffectConfig.Creators.Interfaces;
using PhilipsHue.Effects.Interfaces;
using PhilipsHue.Models.Interfaces;
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
        private MidiVelocity _velocity;
        private MidiNote _note;
        private LightEffect _effect;
        private List<HueLight> _lights;
        private IEffectConfigSet _configuration;
        public MidiChannel Channel { get { return _channel; } set { _channel = value; } }
        public string ChannelName { get { return _channel.Name; } }
        public MidiVelocity Velocity { get { return _velocity; } set { _velocity = value; } }
        public string VelocityName { get { return _velocity.Name; } }
        public MidiNote Note { get { return _note; } set { _note = value; } }
        public string NoteName { get { return _note.Name; } }
        public LightEffect Effect { get { return _effect; } set { _effect = value; } }
        public string EffectName { get { return _effect.Name; } }
        public List<HueLight> Lights { get { return _lights; } set { _lights = value; } }
        public string LightsCountText { get { return _lights.Count > 0 ? _lights.Count + " " + (_lights.Count > 1 ? "lights" : "light") + " linked" : "No lights linked"; } }
        public IEffectConfigSet Configuration { get { return _configuration; } set { _configuration = value; } }

        public MidiEffectLink_ViewModel(MidiChannel channel, MidiVelocity velocity, MidiNote note, 
            LightEffect effect, List<HueLight> lights, IEffectConfigSet configuration)
        {
            _channel = channel;
            _velocity = velocity;
            _note = note;
            _effect = effect;
            _lights = lights;
            _configuration = configuration;
        }
    }
}

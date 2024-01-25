using Control.Models.Structs;
using DataStorage.Models.Interfaces;
using MIDI.Models.Structs;
using PhilipsHue.Actions.Interfaces;
using PhilipsHue.EffectConfig.Creators.Interfaces;
using PhilipsHue.Effects.Interfaces;
using PhilipsHue.Models.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Control.Controllers.Interfaces
{
    public interface IMidiLightsController
    {
        bool CreateLink(MidiMessageViewLightsEffectConfig linkData);
        bool RemoveLink(MidiMessageKeys keys);
        void PerformLinkedAction(MidiLightsController sender, MidiMessageKeys keys);
        void ConnectSystem();
        int GetControllerDeviceCount();
        void CreateLinkHandler(object sender, MidiMessageViewLightsEffectConfig linkData);
        void DeleteLinkHandler(object sender, MidiMessageKeys keys);
    }
}

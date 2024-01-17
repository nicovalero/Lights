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
        bool PerformLinkedAction(MidiMessageKeys keys);
        bool ParseLinks(IHueLinkSaveObject json);
        void ConnectSystem();
        int GetControllerDeviceCount();
        List<LightEffect> GetEffects();
        List<HueLight> GetAllAvailableDevices();
        void CreateLinkHandler(object sender, MidiMessageViewLightsEffectConfig linkData);
        void DeleteLinkHandler(object sender, MidiMessageKeys keys);
        Dictionary<MidiMessageKeys, LightEffectAction> GetMessageActionLinks();
    }
}

using DataStorage.Models.Interfaces;
using MIDI.Models.Structs;
using PhilipsHue.Actions.Interfaces;
using PhilipsHue.Effects.Interfaces;
using PhilipsHue.Models.Interfaces;
using System.Collections.Generic;

namespace Control.Controllers.Interfaces
{
    public interface IPhilipsHueMidiLightsController
    {
        Dictionary<MidiMessageKeys, LightEffectAction> GetMessageActionLinks();
        List<LightEffect> GetEffects();
        List<HueLight> GetAllAvailableDevices();
        bool ParseLinks(IHueLinkSaveObject json);
    }
}

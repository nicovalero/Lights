using MIDI.Models.Structs;
using PhilipsHue.Actions.Interfaces;
using System.Collections.Generic;

namespace Control.Controllers.Interfaces
{
    public interface IHueMidiLightsController
    {
        Dictionary<MidiMessageKeys, LightEffectAction> GetMessageActionLinks();
    }
}

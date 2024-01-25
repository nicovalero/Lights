using DataStorage.Models.Interfaces;
using MIDI.Models.Structs;
using Nanoleaf.Action.Interfaces;
using Nanoleaf.Devices.Interfaces;
using Nanoleaf.Effects.Enums;
using System.Collections.Generic;

namespace Control.Controllers.Interfaces
{
    public interface INanoleafMidiLightsController
    {
        Dictionary<MidiMessageKeys, IAction> GetMessageActionLinks();
        List<AvailableEffects> GetEffects();
        List<IShapesPanel> GetAllAvailableDevices();
        bool ParseLinks(INanoleafLinkSaveObject json);
    }
}

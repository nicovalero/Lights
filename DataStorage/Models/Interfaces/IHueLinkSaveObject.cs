using MIDI.Models.Structs;
using PhilipsHue.Actions.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStorage.Models.Interfaces
{
    public interface IHueLinkSaveObject
    {
        List<KeyValuePair<MidiMessageKeys, LightEffectAction>> Links { get; set; }
    }
}

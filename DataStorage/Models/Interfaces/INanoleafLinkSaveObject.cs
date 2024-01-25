using MIDI.Models.Structs;
using Nanoleaf.Action.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStorage.Models.Interfaces
{
    public interface INanoleafLinkSaveObject
    {
        List<KeyValuePair<MidiMessageKeys, IAction>> Links { get; set; }
    }
}

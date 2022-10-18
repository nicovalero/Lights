using DataStorage.Models.Interfaces;
using MIDI.Models.Structs;
using Newtonsoft.Json;
using PhilipsHue.Actions.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStorage.Models
{
    public class HueLinkSaveObject: LinkSaveObject
    {
        private Dictionary<MidiMessageKeys, LightEffectAction> _links;
        public Dictionary<MidiMessageKeys, LightEffectAction> Links { get { return _links; } set { _links = value; } }
        public HueLinkSaveObject(Dictionary<MidiMessageKeys, LightEffectAction> dictionary)
        {
            _links = dictionary;
        }

        public string GenerateContentToSave()
        {
            return JsonConvert.SerializeObject(Links.ToArray(), Formatting.Indented);
        }
    }
}

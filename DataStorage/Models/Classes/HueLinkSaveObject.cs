using DataStorage.Models.Interfaces;
using MIDI.Models.Structs;
using Newtonsoft.Json;
using PhilipsHue;
using PhilipsHue.Actions.Interfaces;
using PhilipsHue.Effects.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStorage.Models
{
    public class HueLinkSaveObject: IHueLinkSaveObject
    {
        private List<KeyValuePair<MidiMessageKeys, LightEffectAction>> _links;
        public List<KeyValuePair<MidiMessageKeys, LightEffectAction>> Links { get { return _links; } set { _links = value; } }

        public HueLinkSaveObject(Dictionary<MidiMessageKeys, LightEffectAction> dictionary)
        {
            _links = new List<KeyValuePair<MidiMessageKeys, LightEffectAction>>();

            foreach(KeyValuePair<MidiMessageKeys, LightEffectAction> link in dictionary)
            {
                _links.Add(link);
            }
        }

        [JsonConstructor]
        public HueLinkSaveObject(List<KeyValuePair<MidiMessageKeys, LightEffectAction>> list)
        {
            _links = list;
        }
    }
}

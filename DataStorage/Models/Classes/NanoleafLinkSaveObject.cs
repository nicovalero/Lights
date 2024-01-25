using DataStorage.Models.Interfaces;
using MIDI.Models.Structs;
using Nanoleaf.Action.Interfaces;
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
    public class NanoleafLinkSaveObject: INanoleafLinkSaveObject
    {
        [JsonProperty]
        private List<KeyValuePair<MidiMessageKeys, IAction>> _links;

        public List<KeyValuePair<MidiMessageKeys, IAction>> Links { get { return _links; } set { _links = value; } }

        public NanoleafLinkSaveObject(Dictionary<MidiMessageKeys, IAction> dictionary)
        {
            _links = new List<KeyValuePair<MidiMessageKeys, IAction>>();

            foreach(KeyValuePair<MidiMessageKeys, IAction> link in dictionary)
            {
                _links.Add(link);
            }
        }

        [JsonConstructor]
        public NanoleafLinkSaveObject(List<KeyValuePair<MidiMessageKeys, IAction>> list)
        {
            _links = list;
        }
    }
}

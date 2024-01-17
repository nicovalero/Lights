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
    public class MainLinkSaveObject: IMainLinkSaveObject
    {
        public string LinksJson { get; set; }

        [JsonConstructor]
        public MainLinkSaveObject(string json)
        {
            LinksJson = json;
        }
    }
}

using DataStorage.Enums;
using DataStorage.Models.Interfaces;
using MIDI.Models.Structs;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStorage.Models.Classes
{
    public class LinkSaveObject : ILinkSaveObject
    {
        [JsonProperty("LinksJson")]
        public string LinksJson { get; private set; }

        [JsonProperty("PhilipsHueMidiLightsControllerJson")]
        public string PhilipsHueMidiLightsControllerJson { get; private set; }

        public LinkSaveObject(string linksJson, string philipsHueJsonContent)
        {
            this.LinksJson = linksJson;
            this.PhilipsHueMidiLightsControllerJson = philipsHueJsonContent;
        }
    }
}

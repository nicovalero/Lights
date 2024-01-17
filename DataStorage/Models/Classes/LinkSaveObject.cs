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
        [JsonProperty("MainLinksJson")]
        public IMainLinkSaveObject MainLinksJson { get; private set; }

        [JsonProperty("HueLinkSaveObject")]
        public IHueLinkSaveObject PhilipsHueLinkSaveObject { get; private set; }

        public LinkSaveObject(IMainLinkSaveObject linksJson, IHueLinkSaveObject philipsHueLinkSaveObject)
        {
            MainLinksJson = linksJson;
            PhilipsHueLinkSaveObject = philipsHueLinkSaveObject;
        }

        public string SerializeToJSON()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented, new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.Objects,
                TypeNameAssemblyFormat = System.Runtime.Serialization.Formatters.FormatterAssemblyStyle.Simple
            });
        }
    }
}

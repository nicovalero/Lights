using DataStorage.Enums;
using DataStorage.Models.Interfaces;
using MIDI.Models.Structs;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DataStorage.Models.Classes
{
    public class LinkSaveObject : ILinkSaveObject
    {
        [JsonProperty("File Version")]
        public string Version 
        {
            get
            {
                var assembly = Assembly.GetExecutingAssembly();
                return assembly.GetName().Version.ToString();
            }
            private set { }
        }

        [JsonProperty("MainLinksJson")]
        public IMainLinkSaveObject MainLinksJson { get; private set; }

        [JsonProperty("HueLinkSaveObject")]
        public IHueLinkSaveObject PhilipsHueLinkSaveObject { get; set; }

        [JsonProperty("NanoleafLinkSaveObject")]
        public INanoleafLinkSaveObject NanoleafLinkSaveObject { get; set; }

        public LinkSaveObject(IMainLinkSaveObject linksJson, IHueLinkSaveObject philipsHueLinkSaveObject, INanoleafLinkSaveObject nanoleafLinkSaveObject)
        {
            MainLinksJson = linksJson;
            PhilipsHueLinkSaveObject = philipsHueLinkSaveObject;
            NanoleafLinkSaveObject = nanoleafLinkSaveObject;
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

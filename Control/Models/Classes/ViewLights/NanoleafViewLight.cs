using Control.Enums;
using Control.Factories;
using Control.Models.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Control.Models.Classes.ViewEffects
{
    public class NanoleafViewLight : IViewLight
    {
        public string ID { get { return ID; } }
        public string Name { get { return NAME; } }
        public string Description { get { return DESCRIPTION; } }
        private const string DESCRIPTION = "Nanoleaf Panels";
        private const LightType TYPE = LightType.Nanoleaf;
        private const string TYPENAME = "Nanoleaf";
        private readonly string NAME = "Nanoleaf panels";

        [JsonProperty]
        private readonly string id;

        public NanoleafViewLight(string ID)
        {
            this.id = ID;
            this.NAME = ID;
        }
        public string GetDescription()
        {
            return DESCRIPTION;
        }

        public LightType GetLightType()
        {
            return TYPE;
        }

        public string GetName()
        {
            return NAME;
        }

        public string GetEffectTypeName()
        {
            return TYPENAME;
        }

        public string GetID()
        {
            return id;
        }
    }
}

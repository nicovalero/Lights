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
    public class PhilipsHueViewLight : IViewLight
    {
        public string ID { get { return ID; } }
        public string Name { get { return NAME; } }
        public string Description { get { return DESCRIPTION; } }

        [JsonProperty]
        private readonly string DESCRIPTION = "Philips Hue light";

        private const LightType TYPE = LightType.PhilipsHue;
        private const string TYPENAME = "Philips Hue";

        [JsonProperty]
        private readonly string NAME = "Philips Hue Light";
        [JsonProperty]
        private readonly string id;

        public PhilipsHueViewLight(string ID, string lightName, string description)
        {
            this.id = ID;
            NAME = lightName;
            DESCRIPTION = description;
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

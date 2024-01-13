using Control.Enums;
using Control.Factories;
using Control.Models.Interfaces;
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
        private const string DESCRIPTION = "Philips Hue light";
        private const LightType TYPE = LightType.PhilipsHue;
        private const string TYPENAME = "Philips Hue";
        private const string NAME = "Philips Hue Light";
        private readonly string id;

        public PhilipsHueViewLight(string ID)
        {
            this.id = ID;
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

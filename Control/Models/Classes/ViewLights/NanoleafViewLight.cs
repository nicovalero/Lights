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
    public class NanoleafViewLight : IViewLight
    {
        private const string DESCRIPTION = "Nanoleaf Panels";
        private const LightType TYPE = LightType.Nanoleaf;
        private const string TYPENAME = "Nanoleaf";
        private const string NAME = "Nanoleaf panels";
        private readonly string id;

        public NanoleafViewLight(string ID)
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

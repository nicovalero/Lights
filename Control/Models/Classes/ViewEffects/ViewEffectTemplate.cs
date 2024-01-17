﻿using Control.Enums;
using Control.Factories;
using Control.Models.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Control.Models.Classes.ViewLights
{
    public class ViewEffectTemplate : IViewEffect
    {
        [JsonProperty]
        private readonly string DESCRIPTION;
        [JsonProperty]
        private readonly EffectType TYPE;
        [JsonProperty]
        private readonly string TYPENAME;
        [JsonProperty]
        private readonly string NAME;
        [JsonProperty]
        private readonly AvailableViewEffects KIND;

        public ViewEffectTemplate(string DESCRIPTION, EffectType TYPE, string TYPENAME, string NAME, AvailableViewEffects KIND)
        {
            this.DESCRIPTION = DESCRIPTION;
            this.TYPE = TYPE;
            this.TYPENAME = TYPENAME;
            this.NAME = NAME;
            this.KIND = KIND;
        }

        public string GetDescription()
        {
            return DESCRIPTION;
        }

        public EffectType GetEffectType()
        {
            return TYPE;
        }

        public AvailableViewEffects GetKind()
        {
            return KIND;
        }

        public string GetName()
        {
            return NAME;
        }

        public string GetEffectTypeName()
        {
            return TYPENAME;
        }

        public override bool Equals(object obj)
        {
            var concreteObj = (ViewEffectTemplate)obj;
            return concreteObj.GetName() == this.GetName() && concreteObj.GetEffectType() == this.GetEffectType()
                && concreteObj.GetKind() == concreteObj.GetKind();
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}

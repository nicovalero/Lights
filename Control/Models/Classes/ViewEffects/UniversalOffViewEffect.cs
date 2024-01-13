using Control.Enums;
using Control.Factories;
using Control.Models.Classes.ViewLights;
using Control.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Control.Models.Classes.ViewEffects
{
    public class UniversalOffViewEffect : IViewEffect
    {
        private const string DESCRIPTION = "Switches the device off";
        private const EffectType TYPE = EffectType.Universal;
        private const string TYPENAME = "Universal";
        private const string NAME = "Turn Off";
        private const AvailableViewEffects KIND = AvailableViewEffects.UniversalOff;
        public string GetDescription()
        {
            return DESCRIPTION;
        }

        public EffectType GetEffectType()
        {
            return TYPE;
        }

        public string GetName()
        {
            return NAME;
        }

        public AvailableViewEffects GetKind()
        {
            return KIND;
        }

        public string GetEffectTypeName()
        {
            return TYPENAME;
        }

        public override bool Equals(object obj)
        {
            var concreteObj = (UniversalOnViewEffect)obj;
            return concreteObj.GetName() == this.GetName() && concreteObj.GetEffectType() == this.GetEffectType()
                && concreteObj.GetKind() == concreteObj.GetKind();
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}

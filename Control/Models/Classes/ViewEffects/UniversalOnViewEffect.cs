using Control.Enums;
using Control.Factories;
using Control.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Control.Models.Classes.ViewLights
{
    public class UniversalOnViewEffect : IViewEffect
    {
        private const string DESCRIPTION = "Switches the device on";
        private const EffectType TYPE = EffectType.Universal;
        private const string TYPENAME = "Universal";
        private const string NAME = "Turn On";
        private const AvailableViewEffects KIND = AvailableViewEffects.UniversalOn;
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

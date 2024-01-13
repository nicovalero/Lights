using Control.Enums;
using Control.Models.Interfaces;
using PhilipsHue.EffectConfig.Parts.Classes;
using System.Collections.Generic;

namespace Control.Models.Classes.ViewEffectConfigSet
{
    public class NanoleafViewConfigSet : IViewEffectConfigSet
    {
        private Dictionary<EffectConfigPropertyIdentifier, object> effectDictionary;
        public NanoleafViewConfigSet()
        {
            effectDictionary = new Dictionary<EffectConfigPropertyIdentifier, object>();
        }

        public bool ExistsEffectConfig(EffectConfigPropertyIdentifier effectConfigPropertyIdentifier)
        {
            return effectDictionary.ContainsKey(effectConfigPropertyIdentifier);
        }

        public object GetEffectConfigProperty(EffectConfigPropertyIdentifier effectConfigPropertyIdentifier)
        {
            if (effectDictionary.ContainsKey(effectConfigPropertyIdentifier))
            {
                return effectDictionary[effectConfigPropertyIdentifier];
            }
            else
            {
                return null;
            }
        }

        public AvailableViewEffects GetKind()
        {
            return AvailableViewEffects.NanoleafEffect;
        }
    }
}

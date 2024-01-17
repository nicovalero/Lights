using Control.Enums;
using Control.Models.Interfaces;
using Newtonsoft.Json;
using PhilipsHue.EffectConfig.Parts.Classes;
using System.Collections.Generic;

namespace Control.Models.Classes.ViewEffectConfigSet
{
    public class TurnOnViewConfigSet : IViewEffectConfigSet
    {
        [JsonProperty]
        private Dictionary<EffectConfigPropertyIdentifier, object> effectDictionary;
        public TurnOnViewConfigSet()
        {
            effectDictionary = new Dictionary<EffectConfigPropertyIdentifier, object>();
            effectDictionary.Add(EffectConfigPropertyIdentifier.TurnOn, true);
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
            return AvailableViewEffects.UniversalOn;
        }
    }
}

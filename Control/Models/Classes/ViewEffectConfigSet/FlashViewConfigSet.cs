using Control.Enums;
using Control.Models.Interfaces;
using Newtonsoft.Json;
using PhilipsHue.EffectConfig.Parts.Classes;
using System.Collections.Generic;

namespace Control.Models.Classes.ViewEffectConfigSet
{
    public class FlashViewConfigSet : IViewEffectConfigSet
    {
        [JsonProperty]
        private Dictionary<EffectConfigPropertyIdentifier, object> effectDictionary;
        public FlashViewConfigSet(byte brightnessLevel1, byte brightnessLevel2, uint transitionTime)
        {
            effectDictionary = new Dictionary<EffectConfigPropertyIdentifier, object>();
            effectDictionary.Add(EffectConfigPropertyIdentifier.BrightnessStart, brightnessLevel1);
            effectDictionary.Add(EffectConfigPropertyIdentifier.BrightnessFinal, brightnessLevel2);
            effectDictionary.Add(EffectConfigPropertyIdentifier.TransitionTime, transitionTime);
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
            return AvailableViewEffects.UniversalFlash;
        }
    }
}

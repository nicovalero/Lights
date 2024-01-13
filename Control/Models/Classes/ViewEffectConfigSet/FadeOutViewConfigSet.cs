using Control.Enums;
using Control.Models.Interfaces;
using System.Collections.Generic;

namespace Control.Models.Classes.ViewEffectConfigSet
{
    public class FadeOutViewConfigSet : IViewEffectConfigSet
    {
        private byte brightnessLevel;
        private uint transitionTime;
        private Dictionary<EffectConfigPropertyIdentifier, object> effectDictionary;

        public FadeOutViewConfigSet(byte brightnessLevel, uint transitionTime)
        {
            this.brightnessLevel = brightnessLevel;
            this.transitionTime = transitionTime;

            effectDictionary = new Dictionary<EffectConfigPropertyIdentifier, object>();
            effectDictionary.Add(EffectConfigPropertyIdentifier.BrightnessLevel, brightnessLevel);
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
            return AvailableViewEffects.UniversalFadeOut;
        }
    }
}

using Control.Enums;
using Control.Models.Interfaces;
using PhilipsHue.EffectConfig.Parts.Classes;
using System.Collections.Generic;

namespace Control.Models.Classes.ViewEffectConfigSet
{
    public class FlashViewConfigSet : IViewEffectConfigSet
    {
        private byte brightnessLevel1;
        private byte brightnessLevel2;
        private uint transitionTime;
        private Dictionary<EffectConfigPropertyIdentifier, object> effectDictionary;
        public FlashViewConfigSet(byte brightnessLevel1, byte brightnessLevel2, uint transitionTime)
        {
            this.brightnessLevel1 = brightnessLevel1;
            this.brightnessLevel2 = brightnessLevel2;
            this.transitionTime = transitionTime;

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

using Control.Enums;
using Control.Models.Interfaces;
using Newtonsoft.Json;
using PhilipsHue.EffectConfig.Parts.Classes;
using PhilipsHue.EffectConfig.Products.Classes;
using PhilipsHue.EffectConfig.Products.Interfaces;
using System.Collections.Generic;

namespace Control.Models.Classes.ViewEffectConfigSet
{
    public class ColorChangeViewConfigSet: IViewEffectConfigSet
    {
        [JsonProperty]
        private System.Drawing.Color finalColor;
        [JsonProperty]
        private uint transitionTimeConfig;
        [JsonProperty]
        private Dictionary<EffectConfigPropertyIdentifier, object> effectsDictionary;

        public ColorChangeViewConfigSet(System.Drawing.Color finalColor, uint transitionTimeConfig)
        {
            this.finalColor = finalColor;
            this.transitionTimeConfig = transitionTimeConfig;
            effectsDictionary = new Dictionary<EffectConfigPropertyIdentifier, object>();
            effectsDictionary.Add(EffectConfigPropertyIdentifier.Color, finalColor.ToArgb());
            effectsDictionary.Add(EffectConfigPropertyIdentifier.TransitionTime, transitionTimeConfig);
        }

        public bool ExistsEffectConfig(EffectConfigPropertyIdentifier effectConfigPropertyIdentifier)
        {
            return effectsDictionary.ContainsKey(effectConfigPropertyIdentifier);
        }

        public object GetEffectConfigProperty(EffectConfigPropertyIdentifier effectConfigPropertyIdentifier)
        {
            if (effectsDictionary.ContainsKey(effectConfigPropertyIdentifier))
            {
                return effectsDictionary[effectConfigPropertyIdentifier];
            }
            else
            {
                return null;
            }
        }

        public AvailableViewEffects GetKind()
        {
            return AvailableViewEffects.UniversalColorChange;
        }
    }
}

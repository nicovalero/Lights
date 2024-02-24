using Control.Enums;
using Control.Models.Interfaces;
using Newtonsoft.Json;
using PhilipsHue.EffectConfig.Parts.Classes;
using System.Collections.Generic;
using System.Drawing;

namespace Control.Models.Classes.ViewEffectConfigSet
{
    public class TurnOffViewConfigSet : IViewEffectConfigSet
    {
        [JsonProperty]
        private Dictionary<EffectConfigPropertyIdentifier, object> effectDictionary;
        [JsonProperty]
        private System.Drawing.Color finalColor;
        public TurnOffViewConfigSet()
        {
            effectDictionary = new Dictionary<EffectConfigPropertyIdentifier, object>();
            effectDictionary.Add(EffectConfigPropertyIdentifier.TurnOff, true);

            finalColor = Color.FromArgb(0, 0, 0, 0);
            effectDictionary.Add(EffectConfigPropertyIdentifier.Color, finalColor.ToArgb());
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
            return AvailableViewEffects.UniversalOff;
        }
    }
}

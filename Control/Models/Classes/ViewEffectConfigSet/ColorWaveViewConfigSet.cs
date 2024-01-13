using Control.Enums;
using Control.Models.Interfaces;
using PhilipsHue.EffectConfig.Parts.Classes;
using System.Collections.Generic;
using System.Drawing;
using static System.TimeZoneInfo;

namespace Control.Models.Classes.ViewEffectConfigSet
{
    public class ColorWaveViewConfigSet : IViewEffectConfigSet
    {
        private Color color;
        private uint transitionTime;
        private List<IViewLight> lights;
        private uint intervalTime;
        private Dictionary<EffectConfigPropertyIdentifier, object> effectDictionary;

        public ColorWaveViewConfigSet(Color color, uint transitionTime, List<IViewLight> lights, uint intervalTime)
        {
            this.color = color;
            this.intervalTime = intervalTime;
            this.lights = lights;
            this.transitionTime = transitionTime;

            effectDictionary = new Dictionary<EffectConfigPropertyIdentifier, object>();
            effectDictionary.Add(EffectConfigPropertyIdentifier.Color, color);
            effectDictionary.Add(EffectConfigPropertyIdentifier.TransitionTime, transitionTime);
            effectDictionary.Add(EffectConfigPropertyIdentifier.IntervalTime, intervalTime);
            effectDictionary.Add(EffectConfigPropertyIdentifier.LightList, lights);
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
            return AvailableViewEffects.UniversalColorWave;
        }

        public List<IViewLight> GetViewLights()
        {
            return lights;
        }
    }
}

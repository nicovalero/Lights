using Control.Enums;
using Control.Models.Interfaces;
using PhilipsHue.EffectConfig.Parts.Classes;
using System.Collections.Generic;

namespace Control.Models.Classes.ViewEffectConfigSet
{
    public class BrightnessWaveViewConfigSet : IViewEffectConfigSet
    {
        private byte brightnessLevel;
        private uint transitionTime;
        private List<IViewLight> lights;
        private uint intervalTime;
        private Dictionary<EffectConfigPropertyIdentifier, object> effectsDictionary;

        public BrightnessWaveViewConfigSet(byte brightnessLevel, uint transitionTime, List<IViewLight> lights, uint intervalTime)
        {
            this.brightnessLevel = brightnessLevel;
            this.transitionTime = transitionTime;
            this.lights = lights;
            this.intervalTime = intervalTime;

            effectsDictionary = new Dictionary<EffectConfigPropertyIdentifier, object>();
            effectsDictionary.Add(EffectConfigPropertyIdentifier.BrightnessLevel, brightnessLevel);
            effectsDictionary.Add(EffectConfigPropertyIdentifier.TransitionTime, transitionTime);
            effectsDictionary.Add(EffectConfigPropertyIdentifier.IntervalTime, intervalTime);
            effectsDictionary.Add(EffectConfigPropertyIdentifier.LightList, lights);
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
            return AvailableViewEffects.UniversalBrightnessWave;
        }

        public List<IViewLight> GetViewLights()
        {
            return lights;
        }
    }
}

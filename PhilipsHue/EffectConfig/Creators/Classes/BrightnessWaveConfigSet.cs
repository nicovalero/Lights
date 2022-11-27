using PhilipsHue.EffectConfig.Creators.Interfaces;
using PhilipsHue.EffectConfig.Parts.Classes;
using PhilipsHue.EffectConfig.Parts.Interfaces;
using PhilipsHue.EffectConfig.Products.Interfaces;
using PhilipsHue.Models;
using PhilipsHue.Models.Classes;
using PhilipsHue.Models.Enums;
using PhilipsHue.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.TimeZoneInfo;

namespace PhilipsHue.EffectConfig.Creators.Classes
{
    public class BrightnessWaveConfigSet : IEffectConfigSet
    {
        private BrightnessConfig _brightnessConfig;
        private IHueLightListConfig _lightListConfig;
        private IEffectPropertyConfig _transitionTimeConfig;
        private ITimeConfig _intervalTimeConfig;
        private Queue<HueStateJSONProperty> _hueStateQueue;
        
        public BrightnessConfig BrightnessConfig { get => _brightnessConfig; set => _brightnessConfig = value; }
        public IHueLightListConfig LightListConfig { get => _lightListConfig; set => _lightListConfig = value; }
        public IEffectPropertyConfig TransitionTimeConfig { get => _transitionTimeConfig; set => _transitionTimeConfig = value; }
        public ITimeConfig IntervalTimeConfig { get => _intervalTimeConfig; set => _intervalTimeConfig = value; }

        public BrightnessWaveConfigSet(byte firstBrightnessValue, IEffectPropertyConfig transitionConfig, 
            IHueLightListConfig listConfig, ITimeConfig intervalTimeConfig)
        {
            _brightnessConfig = new BrightnessConfig(firstBrightnessValue);
            _transitionTimeConfig = transitionConfig;
            _lightListConfig = listConfig;
            _hueStateQueue = new Queue<HueStateJSONProperty>();
            _intervalTimeConfig = intervalTimeConfig;
        }

        private void RefreshQueue()
        {
            _hueStateQueue.Clear();
            List<IEffectPropertyConfig> list = new List<IEffectPropertyConfig>();

            list.Add(BrightnessConfig);
            list.Add(TransitionTimeConfig);
            HueStateJSONProperty state = GetHueStateJSONProperty(list);

            _hueStateQueue.Enqueue(state);
        }

        private HueStateJSONProperty GetHueStateJSONProperty(List<IEffectPropertyConfig> properties)
        {
            HueState state = new HueState();
            HashSet<HueJSONBodyStateProperty> set = new HashSet<HueJSONBodyStateProperty>();

            foreach (IEffectPropertyConfig property in properties)
            {
                switch (property.JsonProperty)
                {
                    case HueJSONBodyStateProperty.BRI:
                        if (property.Value is byte)
                        {
                            if (!set.Contains(property.JsonProperty))
                                set.Add(property.JsonProperty);
                            state.bri = (byte)property.Value;
                        }
                        break;
                    case HueJSONBodyStateProperty.TRANSITIONTIME:
                        if (property.Value is uint)
                        {
                            if (!set.Contains(property.JsonProperty))
                                set.Add(property.JsonProperty);
                            state.transitiontime = (uint)property.Value;
                        }
                        break;
                    default:
                        break;
                }
            }

            HueStateJSONProperty hueStateJSONProperty = new HueStateJSONProperty(set, state);

            return hueStateJSONProperty;
        }

        public Queue<HueStateJSONProperty> GetHueStateQueue()
        {
            RefreshQueue();
            return _hueStateQueue;
        }
    }
}

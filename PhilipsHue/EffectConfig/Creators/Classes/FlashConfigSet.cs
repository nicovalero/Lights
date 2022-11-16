using PhilipsHue.EffectConfig.Creators.Interfaces;
using PhilipsHue.EffectConfig.Parts.Classes;
using PhilipsHue.EffectConfig.Products.Interfaces;
using PhilipsHue.Models;
using PhilipsHue.Models.Classes;
using PhilipsHue.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhilipsHue.EffectConfig.Creators.Classes
{
    public class FlashConfigSet: IEffectConfigSet
    {
        private BrightnessConfig _finalBrightnessConfig;
        private BrightnessConfig _initialBrightnessConfig;
        private TransitionTimeConfig _transitionTimeConfig;
        private Queue<HueStateJSONProperty> _hueStateQueue;
        public BrightnessConfig FinalBrightnessConfig { get => _finalBrightnessConfig; set => _finalBrightnessConfig = value; }
        public BrightnessConfig InitialBrightnessConfig { get => _initialBrightnessConfig; set => _initialBrightnessConfig = value; }
        public TransitionTimeConfig TransitionTimeConfig { get => _transitionTimeConfig; set => _transitionTimeConfig = value; }

        public FlashConfigSet(byte finalBrightnessValue, byte initialBrightnessValue, uint transitionTime)
        {
            _finalBrightnessConfig = new BrightnessConfig(finalBrightnessValue);
            _initialBrightnessConfig = new BrightnessConfig(initialBrightnessValue);
            _transitionTimeConfig = new TransitionTimeConfig(transitionTime);
            _hueStateQueue = new Queue<HueStateJSONProperty>();
        }

        private void RefreshQueue()
        {
            _hueStateQueue.Clear();
            List<IEffectPropertyConfig> list = new List<IEffectPropertyConfig>();

            list.Add(InitialBrightnessConfig);
            list.Add(TransitionTimeConfig);
            HueStateJSONProperty state = GetHueStateJSONProperty(list);
            _hueStateQueue.Enqueue(state);

            list.Clear();
            list.Add(FinalBrightnessConfig);
            list.Add(TransitionTimeConfig);
            state = GetHueStateJSONProperty(list);
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

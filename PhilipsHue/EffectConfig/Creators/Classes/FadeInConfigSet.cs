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
    public class FadeInConfigSet : IEffectConfigSet
    {
        private BrightnessConfig _firstBrightnessConfig;
        private BrightnessConfig _secondBrightnessConfig;
        private Queue<HueStateJSONProperty> _hueStateQueue;
        public BrightnessConfig FirstBrightnessConfig { get => _firstBrightnessConfig; set => _firstBrightnessConfig = value; }
        public BrightnessConfig SecondBrightnessConfig { get => _secondBrightnessConfig; set => _secondBrightnessConfig = value; }

        public FadeInConfigSet(byte firstBrightnessValue, byte secondBrightnessValue)
        {
            _firstBrightnessConfig = new BrightnessConfig(firstBrightnessValue);
            _secondBrightnessConfig = new BrightnessConfig(secondBrightnessValue);
            _hueStateQueue = new Queue<HueStateJSONProperty>();
        }

        private void RefreshQueue()
        {
            _hueStateQueue.Clear();
            List<IEffectPropertyConfig> list = new List<IEffectPropertyConfig>();

            list.Add(FirstBrightnessConfig);
            HueStateJSONProperty state = GetHueStateJSONProperty(list);
            _hueStateQueue.Enqueue(state);

            list.Clear();
            list.Add(SecondBrightnessConfig);
            state = GetHueStateJSONProperty(list);
            _hueStateQueue.Enqueue(state);
        }

        private HueStateJSONProperty GetHueStateJSONProperty(List<IEffectPropertyConfig> properties)
        {
            HueState state = new HueState();
            HueStateJSONProperty hueStateJSONProperty = new HueStateJSONProperty();

            foreach (IEffectPropertyConfig property in properties)
            {
                switch (property.JsonProperty)
                {
                    case HueJSONBodyStateProperty.BRI:
                        if (property.Value is byte)
                        {
                            if (!hueStateJSONProperty.JsonProperties.Contains(property.JsonProperty))
                                hueStateJSONProperty.JsonProperties.Add(property.JsonProperty);
                            state.bri = (byte)property.Value;
                        }
                        break;
                    default:
                        break;
                }
            }

            hueStateJSONProperty.State = state;

            return hueStateJSONProperty;
        }

        public Queue<HueStateJSONProperty> GetHueStateQueue()
        {
            RefreshQueue();
            return _hueStateQueue;
        }
    }
}

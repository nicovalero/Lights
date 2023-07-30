using PhilipsHue.EffectConfig.Products.Classes;
using PhilipsHue.Models.Enums;
using System.Collections.Generic;
using System.Drawing;
using PhilipsHue.ColorConverters;
using PhilipsHue.EffectConfig.Creators.Interfaces;
using PhilipsHue.Models.Classes;
using PhilipsHue.EffectConfig.Products.Interfaces;
using PhilipsHue.Models;
using System.Linq;
using PhilipsHue.EffectConfig.Parts.Classes;
using PhilipsHue.EffectConfig.Parts.Interfaces;

namespace PhilipsHue.EffectConfig.Creators.Classes
{
    public class TurnOnConfigSet : IEffectConfigSet
    {
        private TurnOnOffConfig _turnOnConfig;
        private Queue<HueStateJSONProperty> _hueStateQueue;
        public TurnOnOffConfig TurnOnConfig { get => _turnOnConfig; set => _turnOnConfig = value; }   

        public TurnOnConfigSet()
        {
            _turnOnConfig = new TurnOnOffConfig(true);
            _hueStateQueue = new Queue<HueStateJSONProperty>();
        }

        private void RefreshQueue()
        {
            _hueStateQueue.Clear();
            List<IEffectPropertyConfig> list = new List<IEffectPropertyConfig>();

            list.Add(TurnOnConfig);
            HueStateJSONProperty state = GetHueStateJSONProperty(list);
            _hueStateQueue.Enqueue(state);
        }

        private HueStateJSONProperty GetHueStateJSONProperty(List<IEffectPropertyConfig> properties)
        {
            HueState state = new HueState();
            HashSet<HueJSONBodyStateProperty> jsonProperties = new HashSet<HueJSONBodyStateProperty>();

            foreach (IEffectPropertyConfig property in properties)
            {
                switch (property.JsonProperty)
                {
                    case HueJSONBodyStateProperty.ON:
                        if (!jsonProperties.Contains(property.JsonProperty))
                            jsonProperties.Add(property.JsonProperty);
                        state.on = (bool)property.Value;
                        break;
                    default:
                        break;
                }
            }

            HueStateJSONProperty hueStateJSONProperty = new HueStateJSONProperty(jsonProperties, state);

            return hueStateJSONProperty;
        }

        public Queue<HueStateJSONProperty> GetHueStateQueue()
        {
            RefreshQueue();
            return _hueStateQueue;
        }
    }
}
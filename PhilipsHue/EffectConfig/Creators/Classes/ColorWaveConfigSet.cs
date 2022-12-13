using PhilipsHue.ColorConverters;
using PhilipsHue.EffectConfig.Creators.Interfaces;
using PhilipsHue.EffectConfig.Parts.Classes;
using PhilipsHue.EffectConfig.Parts.Interfaces;
using PhilipsHue.EffectConfig.Products.Classes;
using PhilipsHue.EffectConfig.Products.Interfaces;
using PhilipsHue.Models;
using PhilipsHue.Models.Classes;
using PhilipsHue.Models.Enums;
using PhilipsHue.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.TimeZoneInfo;

namespace PhilipsHue.EffectConfig.Creators.Classes
{
    public class ColorWaveConfigSet : IEffectConfigSet
    {
        private ColorConfig _colorConfig;
        private IHueLightListConfig _lightListConfig;
        private IEffectPropertyConfig _transitionTimeConfig;
        private ITimeConfig _intervalTimeConfig;
        private Queue<HueStateJSONProperty> _hueStateQueue;
        
        public ColorConfig ColorConfig { get => _colorConfig; set => _colorConfig = value; }
        public IHueLightListConfig LightListConfig { get => _lightListConfig; set => _lightListConfig = value; }
        public IEffectPropertyConfig TransitionTimeConfig { get => _transitionTimeConfig; set => _transitionTimeConfig = value; }
        public ITimeConfig IntervalTimeConfig { get => _intervalTimeConfig; set => _intervalTimeConfig = value; }

        public ColorWaveConfigSet(Color newValue, IEffectPropertyConfig transitionConfig, 
            IHueLightListConfig listConfig, ITimeConfig intervalTimeConfig)
        {
            _colorConfig = GetFinalColor(newValue);
            _transitionTimeConfig = transitionConfig;
            _lightListConfig = listConfig;
            _hueStateQueue = new Queue<HueStateJSONProperty>();
            _intervalTimeConfig = intervalTimeConfig;
        }

        public ColorConfig GetFinalColor(Color newValue)
        {
            Dictionary<string, double> d = ConvertToXYDictionary(newValue);
            if (d.ContainsKey("x") && d.ContainsKey("y"))
                return new ColorConfig(d["x"], d["y"], newValue);
            else
                return null;
        }

        private Dictionary<string, double> ConvertToXYDictionary(Color value)
        {
            return HueColorConverter.TransformRGBtoXY(value);
        }

        private void RefreshQueue()
        {
            _hueStateQueue.Clear();
            List<IEffectPropertyConfig> list = new List<IEffectPropertyConfig>();

            list.Add(ColorConfig);
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
                    case HueJSONBodyStateProperty.XY:
                        if (property.Value is Dictionary<string, double>)
                        {
                            List<double> values = ((Dictionary<string, double>)property.Value).Values.ToList();

                            List<float> floatValues = new List<float>();
                            try
                            {
                                if (values.Count == 2)
                                {
                                    floatValues.Add((float)values[0]);
                                    floatValues.Add((float)values[1]);

                                    state.xy = floatValues;

                                    //Adds the JsonProperty if it doesn't exist yet
                                    if (!set.Contains(property.JsonProperty))
                                        set.Add(property.JsonProperty);
                                }
                            }
                            catch { }
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

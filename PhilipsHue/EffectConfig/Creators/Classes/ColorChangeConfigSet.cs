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

namespace PhilipsHue.EffectConfig.Creators.Classes
{
    public class ColorChangeConfigSet : IEffectConfigSet
    {
        private ColorConfig _finalColor;
        private TransitionTimeConfig _transitionTimeConfig;
        private Queue<HueStateJSONProperty> _hueStateQueue;
        public ColorConfig FinalColor
        {
            get { return _finalColor; }
            set { _finalColor = value; }
        }
        public TransitionTimeConfig TransitionTimeConfig { get => _transitionTimeConfig; set => _transitionTimeConfig = value; }

        public ColorChangeConfigSet(Color newValue, uint transitionTime)
        {
            FillFinalColor(newValue);
            _hueStateQueue = new Queue<HueStateJSONProperty>();
            _transitionTimeConfig = new TransitionTimeConfig(transitionTime);
        }

        public void FillFinalColor(Color newValue)
        {
            Dictionary<string, double> d = ConvertToXYDictionary(newValue);
            if (d.ContainsKey("x") && d.ContainsKey("y"))
                _finalColor = new ColorConfig(d["x"], d["y"]);
        }

        private Dictionary<string, double> ConvertToXYDictionary(Color value)
        {
            return HueColorConverter.TransformRGBtoXY(value);
        }

        private void RefreshQueue()
        {
            _hueStateQueue.Clear();
            List<IEffectPropertyConfig> list = new List<IEffectPropertyConfig>();

            list.Add(FinalColor);
            list.Add(TransitionTimeConfig);
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
                                    if (!jsonProperties.Contains(property.JsonProperty))
                                        jsonProperties.Add(property.JsonProperty);
                                }
                            }
                            catch { }
                        }
                        break;
                    case HueJSONBodyStateProperty.TRANSITIONTIME:
                        if (property.Value is uint)
                        {
                            if (!jsonProperties.Contains(property.JsonProperty))
                                jsonProperties.Add(property.JsonProperty);
                            state.transitiontime = (uint)property.Value;
                        }
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
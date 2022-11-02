using PhilipsHue.EffectConfig.Products.Classes;
using PhilipsHue.Models.Enums;
using System.Collections.Generic;
using System.Drawing;
using PhilipsHue.ColorConverters;
using PhilipsHue.EffectConfig.Creators.Interfaces;
using PhilipsHue.Models.Classes;
using PhilipsHue.EffectConfig.Products.Interfaces;
using PhilipsHue.Models;

namespace PhilipsHue.EffectConfig.Creators.Classes
{
    public class ColorChangeConfigSet: IEffectConfigSet
    {
        private ColorConfig _finalColor;
        private Queue<HueStateJSONProperty> _hueStateQueue;
        public ColorConfig FinalColor
        {
            get { return _finalColor; }
            set { _finalColor = value; }
        }
        public ColorChangeConfigSet(Color newValue) {
            FillFinalColor(newValue);
            _hueStateQueue = new Queue<HueStateJSONProperty>();
        }

        public void FillFinalColor(Color newValue)
        {
            Dictionary<string, double> d = ConvertToXYDictionary(newValue);
            if (d.ContainsKey("x") && d.ContainsKey("y"))
                _finalColor = new ColorConfig(d["x"], d["y"]);
        }

        private Dictionary<string,double> ConvertToXYDictionary(Color value)
        {
            return HueColorConverter.TransformRGBtoXY(value);
        }

        private void RefreshQueue()
        {
            _hueStateQueue.Clear();
            List<IEffectPropertyConfig> list = new List<IEffectPropertyConfig>();

            list.Add(FinalColor);
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
                        if (property.Value is List<double> || property.Value is List<float>)
                        {
                            //Adds the JsonProperty if it doesn't exist yet
                            if(!jsonProperties.Contains(property.JsonProperty))
                                jsonProperties.Add(property.JsonProperty);

                            if(property.Value is List<double>)
                            {
                                List<float> list = new List<float>();
                                double x = ((List<double>)property.Value)[0];
                                double y = ((List<double>)property.Value)[1];

                                list.Add((float)x);
                                list.Add((float)y);
                                state.xy = list;
                            }
                            else
                                state.xy = (List<float>)property.Value;
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
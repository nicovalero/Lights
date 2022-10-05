using Newtonsoft.Json;
using PhilipsHue.Models.Enums;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace PhilipsHue.Models.Classes
{
    public class HueState
    {
        public bool on;
        public int bri;
        public ushort hue;
        public int sat;
        public string effect;
        public List<float> xy;
        public int ct;
        public string alert;
        public string colorMode;
        public string mode;
        public bool reachable;
        public readonly Dictionary<HueJSONBodyStateProperty, string> jsonProperties;

        public HueState()
        {
            this.on = false;
            this.bri = 0;
            this.hue = 0;
            this.sat = 0;
            this.effect = "";
            this.xy = new List<float>();
            this.ct = 0;
            this.alert = "";
            this.colorMode = "";
            this.mode = "";
            this.reachable = false;
            this.jsonProperties = FillJSONProperties();
        }

        public HueState(bool on, int bri, ushort hue, int sat, string effect, List<float> xy, int ct, string alert, string colorMode, string mode, bool reachable)
        {
            this.on = on;
            this.bri = bri;
            this.hue = hue;
            this.sat = sat;
            this.effect = effect;
            this.xy = xy;
            this.ct = ct;
            this.alert = alert;
            this.colorMode = colorMode;
            this.mode = mode;
            this.reachable = reachable;
            this.jsonProperties = FillJSONProperties();
        }

        private Dictionary<HueJSONBodyStateProperty, string> FillJSONProperties()
        {
            Dictionary<HueJSONBodyStateProperty, string> properties = new Dictionary<HueJSONBodyStateProperty, string>();

            properties.Add(HueJSONBodyStateProperty.ON, "on");
            properties.Add(HueJSONBodyStateProperty.BRI, "bri");
            properties.Add(HueJSONBodyStateProperty.HUE, "hue");
            properties.Add(HueJSONBodyStateProperty.SAT, "sat");
            properties.Add(HueJSONBodyStateProperty.EFFECT, "effect");
            properties.Add(HueJSONBodyStateProperty.XY, "xy");
            properties.Add(HueJSONBodyStateProperty.CT, "ct");
            properties.Add(HueJSONBodyStateProperty.ALERT, "alert");
            properties.Add(HueJSONBodyStateProperty.COLORMODE, "colormode");
            properties.Add(HueJSONBodyStateProperty.MODE, "mode");
            properties.Add(HueJSONBodyStateProperty.REACHABLE, "reachable");

            return properties;
        }

        public void SetOn(bool on)
        {
            this.on = on;
        }

        public StringContent GenerateJSONBody(List<HueJSONBodyStateProperty> properties)
        {
            Dictionary<string, object> list = new Dictionary<string, object>();

            foreach(HueJSONBodyStateProperty property in properties)
            {
                if (this.jsonProperties.ContainsKey(property))
                {
                    object value;
                    switch (property)
                    {
                        case HueJSONBodyStateProperty.ON:
                            value = this.on;
                            break;
                        case HueJSONBodyStateProperty.BRI:
                            value = this.bri;
                            break;
                        case HueJSONBodyStateProperty.HUE:
                            value = this.hue;
                            break;
                        case HueJSONBodyStateProperty.SAT:
                            value = this.sat;
                            break;
                        case HueJSONBodyStateProperty.EFFECT:
                            value = this.effect;
                            break;
                        case HueJSONBodyStateProperty.XY:
                            value = this.xy;
                            break;
                        case HueJSONBodyStateProperty.CT:
                            value = this.ct;
                            break;
                        case HueJSONBodyStateProperty.ALERT:
                            value = this.alert;
                            break;
                        case HueJSONBodyStateProperty.COLORMODE:
                            value = this.colorMode;
                            break;
                        case HueJSONBodyStateProperty.MODE:
                            value = this.mode;
                            break;
                        case HueJSONBodyStateProperty.REACHABLE:
                            value = this.reachable;
                            break;
                    default:
                            value = "";
                            break;
                    }
                    list.Add(this.jsonProperties[property], value);
                }
            }

            var result = JsonConvert.SerializeObject(list);
            var data = new StringContent(result, Encoding.UTF8, "application/json");

            return data;
        }
    }
}

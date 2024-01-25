using Nanoleaf.EffectConfig.Enums;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace Nanoleaf.Network.Classes
{
    public class DeviceState
    {
        public bool on;
        public int brightness;
        public ushort hue;
        public int sat;
        public int ct;
        public string colorMode;
        internal readonly HashSet<string> jsonProperties;

        public DeviceState()
        {
            this.on = false;
            this.brightness = 0;
            this.hue = 0;
            this.sat = 0;
            this.ct = 0;
            this.colorMode = "";
            this.jsonProperties = FillJSONProperties();
        }

        public DeviceState(bool on, int bri, ushort hue, int sat, string effect, List<float> xy, int ct, string alert, string colorMode, string mode, bool reachable, uint transitiontime)
        {
            this.on = on;
            this.brightness = bri;
            this.hue = hue;
            this.sat = sat;
            this.ct = ct;
            this.colorMode = colorMode;
            this.jsonProperties = FillJSONProperties();
        }

        private HashSet<string> FillJSONProperties()
        {
            HashSet<string> properties = new HashSet<string>();

            properties.Add(JSONBodyStateProperty.ON);
            properties.Add(JSONBodyStateProperty.BRIGHTNESS);
            properties.Add(JSONBodyStateProperty.HUE);
            properties.Add(JSONBodyStateProperty.SAT);
            properties.Add(JSONBodyStateProperty.CT);

            return properties;
        }

        public void SetOn(bool on)
        {
            this.on = on;
        }

        public StringContent GenerateJSONBody(List<string> properties)
        {
            Dictionary<string, object> dictionary = new Dictionary<string, object>();

            foreach(string property in properties)
            {
                if (this.jsonProperties.Contains(property))
                {
                    object value;
                    switch (property)
                    {
                        case JSONBodyStateProperty.ON:
                            value = this.on;
                            break;
                        case JSONBodyStateProperty.BRIGHTNESS:
                            value = this.brightness;
                            break;
                        case JSONBodyStateProperty.HUE:
                            value = this.hue;
                            break;
                        case JSONBodyStateProperty.SAT:
                            value = this.sat;
                            break;
                        case JSONBodyStateProperty.CT:
                            value = this.ct;
                            break;
                        case JSONBodyStateProperty.COLORMODE:
                            value = this.colorMode;
                            break;
                        default:
                            value = "";
                            break;
                    }
                    dictionary.Add(property, value);
                }
            }

            var result = JsonConvert.SerializeObject(dictionary);
            var data = new StringContent(result, Encoding.UTF8, "application/json");

            return data;
        }
    }
}

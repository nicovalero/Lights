using PhilipsHue.EffectConfig.Products.Interfaces;
using PhilipsHue.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhilipsHue.EffectConfig.Parts.Classes
{
    public class BrightnessConfig : IEffectPropertyConfig
    {
        private readonly HueJSONBodyStateProperty _jsonProperty = HueJSONBodyStateProperty.BRI;
        private byte _value;
        public HueJSONBodyStateProperty JsonProperty { get => _jsonProperty; }
        public object Value { get => _value; set { _value = (byte)value; } }

        public BrightnessConfig(byte value)
        {
            _value = value;
        }
    }
}

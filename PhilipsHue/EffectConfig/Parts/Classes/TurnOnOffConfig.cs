using PhilipsHue.EffectConfig.Products.Interfaces;
using PhilipsHue.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhilipsHue.EffectConfig.Parts.Classes
{
    public class TurnOnOffConfig : IEffectPropertyConfig
    {
        private readonly HueJSONBodyStateProperty _jsonProperty = HueJSONBodyStateProperty.ON;
        private bool _value;
        public HueJSONBodyStateProperty JsonProperty { get => _jsonProperty; }
        public object Value { get => _value; set { _value = (bool)value; } }

        public TurnOnOffConfig(bool value)
        {
            _value = value;
        }
    }
}

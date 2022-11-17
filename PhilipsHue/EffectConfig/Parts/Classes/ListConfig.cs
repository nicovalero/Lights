using PhilipsHue.EffectConfig.Products.Interfaces;
using PhilipsHue.Models.Enums;
using PhilipsHue.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhilipsHue.EffectConfig.Parts.Classes
{
    public class ListConfig : IEffectPropertyConfig
    {
        private readonly HueJSONBodyStateProperty _jsonProperty = HueJSONBodyStateProperty.BRI;
        private List<HueLight> _value;
        public HueJSONBodyStateProperty JsonProperty { get => _jsonProperty; }
        public object Value { get => _value; set { _value = (List<HueLight>)value; } }

        public ListConfig(List<HueLight> value)
        {
            _value = value;
        }
    }
}

using PhilipsHue.EffectConfig.Parts.Interfaces;
using PhilipsHue.EffectConfig.Products.Interfaces;
using PhilipsHue.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhilipsHue.EffectConfig.Parts.Classes
{
    public class TransitionTimeConfig : IEffectPropertyConfig, ITimeConfig
    {
        private readonly HueJSONBodyStateProperty _jsonProperty = HueJSONBodyStateProperty.TRANSITIONTIME;
        private uint _value;
        public HueJSONBodyStateProperty JsonProperty { get => _jsonProperty; }
        public object Value { get => _value; set { _value = (uint)value; } }

        public TransitionTimeConfig(uint value)
        {
            _value = value;
        }

        public uint GetTimeInMiliseconds()
        {
            uint result = 0;
            if (Value is int || Value is uint)
            {
                result = (uint)Value;
                return result * 100;
            }
            else
                return 0;
        }
    }
}

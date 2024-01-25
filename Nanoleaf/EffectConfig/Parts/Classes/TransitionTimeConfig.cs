using Nanoleaf.EffectConfig.Parts.Interfaces;
using Nanoleaf.EffectConfig.Products.Interfaces;
using Nanoleaf.EffectConfig.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nanoleaf.EffectConfig.Parts.Classes
{
    public class TransitionTimeConfig : IEffectPropertyConfig, ITimeConfig
    {
        private uint _value;
        public string JsonProperty { get => null;/*JSONBodyStateProperty.TRANSITIONTIME;*/ }
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

        public uint GetTimeInTenthOfSeconds()
        {
            uint result = 0;
            if (Value is int || Value is uint)
            {
                result = (uint)Value;
                return result;
            }
            else
                return 0;
        }
    }
}

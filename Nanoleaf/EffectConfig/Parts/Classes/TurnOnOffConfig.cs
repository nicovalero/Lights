using Nanoleaf.EffectConfig.Products.Interfaces;
using Nanoleaf.EffectConfig.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nanoleaf.EffectConfig.Parts.Classes
{
    public class TurnOnOffConfig : IEffectPropertyConfig
    {
        private bool _value;
        public string JsonProperty { get => JSONBodyStateProperty.ON; }
        public object Value { get => _value; set { _value = (bool)value; } }

        public TurnOnOffConfig(bool value)
        {
            _value = value;
        }
    }
}

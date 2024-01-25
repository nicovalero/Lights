using Nanoleaf.EffectConfig.Products.Interfaces;
using Nanoleaf.EffectConfig.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nanoleaf.Devices.Interfaces;

namespace Nanoleaf.EffectConfig.Parts.Classes
{
    public class ListConfig : IEffectPropertyConfig
    {
        private List<IShapesPanel> _value;
        public string JsonProperty { get => JSONBodyStateProperty.BRIGHTNESS; }
        public object Value { get => _value; set { _value = (List<IShapesPanel>)value; } }

        public ListConfig(List<IShapesPanel> value)
        {
            _value = value;
        }
    }
}

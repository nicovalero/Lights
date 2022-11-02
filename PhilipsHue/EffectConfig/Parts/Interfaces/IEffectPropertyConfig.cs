using PhilipsHue.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhilipsHue.EffectConfig.Products.Interfaces
{
    public interface IEffectPropertyConfig
    {
        HueJSONBodyStateProperty JsonProperty { get; }
        object Value { get; set; }
    }
}

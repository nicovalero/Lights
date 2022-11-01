using PhilipsHue.EffectConfig.Creators.Interfaces;
using PhilipsHue.Models.Enums;
using PhilipsHue.Models.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace PhilipsHue.Effects.Interfaces
{
    public interface LightEffect
    {
        string Name { get; }
        string EffectTypeName { get; }
        void Perform(List<HueLight> lightIds, IEffectConfigSet value);
    }
}

using PhilipsHue.EffectConfig.Creators.Interfaces;
using PhilipsHue.Effects.Interfaces;
using PhilipsHue.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Control.Models.Interfaces
{
    public interface IControlledLightEffectAction
    {
        LightEffect GetEffect();
        List<HueLight> GetLights();
        IEffectConfigSet GetConfiguration();
    }
}

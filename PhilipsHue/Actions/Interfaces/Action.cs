using PhilipsHue.EffectConfig.Creators.Interfaces;
using PhilipsHue.Effects.Interfaces;
using PhilipsHue.Models.Interfaces;
using System.Collections.Generic;

namespace PhilipsHue.Actions.Interfaces
{
    public interface LightEffectAction
    {
        void Perform(Dictionary<string, Bridge> dictionary);
        LightEffect GetEffect();
        List<HueLight> GetLights();
        IEffectConfigSet GetConfiguration();
    }
}

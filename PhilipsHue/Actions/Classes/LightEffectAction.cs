using PhilipsHue.Actions.Interfaces;
using PhilipsHue.Effects.Interfaces;
using PhilipsHue.Models.Interfaces;
using System.Collections.Generic;

namespace PhilipsHue.Actions.Classes
{
    public class SingleLightEffectAction: LightEffectAction
    {
        private List<string> _externalLightId;
        private HueLight _light;
        private LightEffect _effect;
        private object _value;

        public SingleLightEffectAction(List<string> externalLightId, HueLight light, LightEffect effect, object value)
        {
            this._externalLightId = externalLightId;
            this._light = light;
            this._effect = effect;
            _value = value;
        }

        public void Perform()
        {
            _effect.Perform(_externalLightId, _value);
        }
    }
}

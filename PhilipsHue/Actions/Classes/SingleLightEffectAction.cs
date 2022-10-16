using PhilipsHue.Actions.Interfaces;
using PhilipsHue.Effects.Interfaces;
using System.Collections.Generic;

namespace PhilipsHue.Actions.Classes
{
    public class SingleLightEffectAction: LightEffectAction
    {
        private List<string> _externalLightId;
        private LightEffect _effect;
        private object _value;

        public SingleLightEffectAction(List<string> externalLightId, LightEffect effect, object value)
        {
            this._externalLightId = externalLightId;
            this._effect = effect;
            _value = value;
        }

        public void Perform()
        {
            _effect.Perform(_externalLightId, _value);
        }

        public LightEffect GetEffect()
        {
            return _effect;
        }
    }
}

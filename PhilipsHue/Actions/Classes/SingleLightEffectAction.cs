using PhilipsHue.Actions.Interfaces;
using PhilipsHue.Effects.Interfaces;
using PhilipsHue.Models.Interfaces;
using System.Collections.Generic;

namespace PhilipsHue.Actions.Classes
{
    public class SingleLightEffectAction: LightEffectAction
    {
        private List<HueLight> _lights;
        private LightEffect _effect;
        private object _value;

        public SingleLightEffectAction(List<HueLight> lights, LightEffect effect, object value)
        {
            this._lights = lights;
            this._effect = effect;
            _value = value;
        }

        public void Perform()
        {
            _effect.Perform(_lights, _value);
        }

        public LightEffect GetEffect()
        {
            return _effect;
        }
    }
}

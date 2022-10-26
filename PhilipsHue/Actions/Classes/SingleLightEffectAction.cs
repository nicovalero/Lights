using Newtonsoft.Json;
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
        private object _configuration;

        public List<HueLight> Lights {  get { return _lights; } set { _lights = value; } }
        public LightEffect Effect{ get { return _effect; } set { _effect = value; } }
        public object Configuration { get { return _configuration; } set { _configuration = value; } }

        public SingleLightEffectAction(List<HueLight> lights, LightEffect effect, object configuration = null)
        {
            this._lights = lights;
            this._effect = effect;
            _configuration = configuration;
        }

        public void Perform()
        {
            _effect.Perform(_lights, _configuration);
        }

        public LightEffect GetEffect()
        {
            return _effect;
        }

        public List<HueLight> GetLights()
        {
            return _lights;
        }
    }
}

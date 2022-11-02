using Newtonsoft.Json;
using PhilipsHue.Actions.Interfaces;
using PhilipsHue.EffectConfig.Creators.Interfaces;
using PhilipsHue.Effects.Interfaces;
using PhilipsHue.Models.Interfaces;
using System.Collections.Generic;

namespace PhilipsHue.Actions.Classes
{
    public class SingleLightEffectAction: LightEffectAction
    {
        private List<HueLight> _lights;
        private LightEffect _effect;
        private IEffectConfigSet _configuration;

        public List<HueLight> Lights {  get { return _lights; } set { _lights = value; } }
        public LightEffect Effect{ get { return _effect; } set { _effect = value; } }
        public IEffectConfigSet Configuration { get { return _configuration; } set { _configuration = value; } }

        public SingleLightEffectAction(List<HueLight> lights, LightEffect effect, IEffectConfigSet configuration = null)
        {
            this._lights = lights;
            this._effect = effect;
            _configuration = configuration;
        }

        public void Perform()
        {
            _effect.Perform(_lights, Configuration);
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

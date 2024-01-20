using Newtonsoft.Json;
using PhilipsHue.Actions.Interfaces;
using PhilipsHue.EffectConfig.Creators.Interfaces;
using PhilipsHue.Effects.Classes;
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

            //This needs to be done in the event of Singleton or not Singleton effects.
            //To be fair, it might not make sense to use the effects as Singletons at all.
            switch(effect)
            {
                case Flash f:
                    _effect = new Flash();
                    break;
                default:
                    this._effect = effect;
                    break;
            }
            _configuration = configuration;
        }

        public void Perform(Dictionary<string, Bridge> dictionary)
        {
            _effect.Perform(dictionary, _lights, Configuration);
        }

        public LightEffect GetEffect()
        {
            return Effect;
        }

        public List<HueLight> GetLights()
        {
            return Lights;
        }

        public IEffectConfigSet GetConfiguration()
        {
            return Configuration;
        }
    }
}

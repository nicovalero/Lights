using Control.Models.Interfaces;
using PhilipsHue.Actions.Interfaces;
using PhilipsHue.EffectConfig.Creators.Interfaces;
using PhilipsHue.Effects.Interfaces;
using PhilipsHue.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Control.Classes
{
    internal class PhilipsHueControlledLightEffectAction : IControlledLightEffectAction
    {
        private readonly LightEffectAction lightEffectAction;

        public PhilipsHueControlledLightEffectAction(LightEffectAction lightEffectAction)
        {
            this.lightEffectAction = lightEffectAction;
        }

        public IEffectConfigSet GetConfiguration()
        {
            return lightEffectAction.GetConfiguration();
        }

        public LightEffect GetEffect()
        {
            return lightEffectAction.GetEffect();
        }

        public List<HueLight> GetLights()
        {
            return lightEffectAction.GetLights();
        }

        public void Perform()
        {
            lightEffectAction.Perform();
        }
    }
}

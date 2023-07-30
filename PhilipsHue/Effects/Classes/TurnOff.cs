using PhilipsHue.Collections;
using PhilipsHue.Controllers;
using PhilipsHue.EffectConfig.Creators.Interfaces;
using PhilipsHue.Effects.Interfaces;
using PhilipsHue.Models;
using PhilipsHue.Models.Classes;
using PhilipsHue.Models.Enums;
using PhilipsHue.Models.Interfaces;
using System.Collections.Generic;

namespace PhilipsHue.Effects.Classes
{
    public class TurnOff: LightEffect
    {
        private static readonly HueLightController _controller = HueLightController.Singleton();
        private const string _name = "Turn Off";
        private const HueLightEffectKindEnum _effectType = HueLightEffectKindEnum.MULTI;
        public string Name { get { return _name; } }
        public string EffectTypeName { get { return HueLightEffectKindCollection.GetKindName(_effectType); } }

        public TurnOff()
        {

        }

        public async void Perform(List<HueLight> lights, IEffectConfigSet config)
        {
            try
            {
                foreach (HueStateJSONProperty combo in  config.GetHueStateQueue())
                {
                    foreach (HueLight light in lights)
                        await _controller.ChangeLightState(light.uniqueId, combo);
                }
            }
            catch { }
        }

        public string GetName()
        {
            return _name;
        }
    }
}

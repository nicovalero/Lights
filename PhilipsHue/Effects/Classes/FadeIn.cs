using PhilipsHue.Collections;
using PhilipsHue.Controllers;
using PhilipsHue.EffectConfig.Creators.Classes;
using PhilipsHue.EffectConfig.Creators.Interfaces;
using PhilipsHue.Effects.Interfaces;
using PhilipsHue.Models;
using PhilipsHue.Models.Classes;
using PhilipsHue.Models.Enums;
using PhilipsHue.Models.Interfaces;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace PhilipsHue.Effects.Classes
{

    public class FadeIn : LightEffect
    {
        private static readonly FadeIn _fadeIn = new FadeIn();
        private static readonly HueLightController _controller = HueLightController.Singleton();
        private const string _name = "Fade in";
        private const HueLightEffectKindEnum _effectType = HueLightEffectKindEnum.MULTI;
        public string Name { get { return _name; } }
        public string EffectTypeName { get { return HueLightEffectKindCollection.GetKindName(_effectType); } }

        private FadeIn() { }

        public static FadeIn Singleton()
        {
            return _fadeIn;
        }

        public async void Perform(List<HueLight> lights, IEffectConfigSet config = null)
        {
            if (config is FadeInConfigSet)
            {
                //Maybe the queue logic should be done in this class instead of the config class
                Queue<HueStateJSONProperty> queue = config.GetHueStateQueue();

                foreach (HueStateJSONProperty c in queue)
                {
                    foreach (HueLight light in lights)
                        await ChangeLightState(light, c);
                }
            }
        }

        private async Task ChangeLightState(HueLight light, HueStateJSONProperty combo)
        {
            await _controller.ChangeLightState(light.uniqueId, combo);
        }

        public string GetName()
        {
            return _name;
        }
    }
}

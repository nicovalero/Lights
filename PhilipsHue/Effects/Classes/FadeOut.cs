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
    public class FadeOut : LightEffect
    {
        private static readonly FadeOut _fadeOut = new FadeOut();
        private static readonly HueLightController _controller = HueLightController.Singleton();
        private const string _name = "Fade out";
        private const HueLightEffectKindEnum _effectType = HueLightEffectKindEnum.MULTI;
        public string Name { get { return _name; } }
        public string EffectTypeName { get { return HueLightEffectKindCollection.GetKindName(_effectType); } }

        private FadeOut() { }

        public static FadeOut Singleton()
        {
            return _fadeOut;
        }

        public async void Perform(List<HueLight> lights, IEffectConfigSet config = null)
        {
            if (config is FadeOutConfigSet)
            {
                //Maybe the queue logic should be done in this class instead of the config class
                Queue<HueStateJSONProperty> queue = config.GetHueStateQueue();

                try
                {
                    foreach (HueStateJSONProperty c in queue)
                    {
                        foreach (HueLight light in lights)
                            await ChangeLightState(light, c);
                    }
                }
                catch { }
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

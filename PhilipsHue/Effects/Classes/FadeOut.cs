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
        private static readonly HueLightController _controller = HueLightController.Singleton();
        private const string _name = "Fade out";
        private const HueLightEffectKindEnum _effectType = HueLightEffectKindEnum.MULTI;
        public string Name { get { return _name; } }
        public string EffectTypeName { get { return HueLightEffectKindCollection.GetKindName(_effectType); } }

        public FadeOut()
        {
        }

        public void Perform(List<HueLight> lights, IEffectConfigSet config = null)
        {
            if (config is FadeOutConfigSet)
            {
                //Maybe the queue logic should be done in this class instead of the config class
                Queue<HueStateJSONProperty> queue = config.GetHueStateQueue();

                foreach (HueStateJSONProperty c in queue)
                {
                    ThreadPool.QueueUserWorkItem((state) =>
                    {
                        foreach (HueLight light in lights)
                        {
                            ChangeLightState(light, c);
                        }
                    });
                }
            }
        }

        private Task ChangeLightState(HueLight light, HueStateJSONProperty combo)
        {
            return _controller.ChangeLightState(light.uniqueId, combo);
        }

        public string GetName()
        {
            return _name;
        }
    }
}

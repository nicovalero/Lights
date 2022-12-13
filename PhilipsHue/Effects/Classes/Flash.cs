using PhilipsHue.Collections;
using PhilipsHue.Controllers;
using PhilipsHue.EffectConfig.Creators.Interfaces;
using PhilipsHue.Effects.Interfaces;
using PhilipsHue.Models;
using PhilipsHue.Models.Classes;
using PhilipsHue.Models.Enums;
using PhilipsHue.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace PhilipsHue.Effects.Classes
{
    public class Flash : LightEffect
    {
        //private static readonly Flash _flash = new Flash();
        private static readonly HueLightController _controller = HueLightController.Singleton();
        private const string _name = "Flash";
        private const HueLightEffectKindEnum _effectType = HueLightEffectKindEnum.MULTI;
        public string Name { get { return _name; } }
        public string EffectTypeName { get { return HueLightEffectKindCollection.GetKindName(_effectType); } }

        public Flash() { }

        //public static Flash Singleton()
        //{
        //    return _flash;
        //}

        public async void Perform(List<HueLight> lights, IEffectConfigSet config)
        {
            //Maybe the queue logic should be done in this class instead of the config class
            Queue<HueStateJSONProperty> queue = config.GetHueStateQueue();

            while(queue.Count > 0)
            {
                HueStateJSONProperty c = queue.Dequeue();
                Parallel.ForEach(lights, light =>
                {
                    _controller.ChangeLightState(light.uniqueId, c);
                });
            }
        }
    }
}

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
using System.Linq;
using System.Reflection;
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

        public void Perform(List<HueLight> lights, IEffectConfigSet config)
        {
            //Maybe the queue logic should be done in this class instead of the config class
            List<HueStateJSONProperty> queue = config.GetHueStateQueue().ToList();
            short flag = 0;
            short nStates = (short)queue.Count;
            Semaphore startFlag = new Semaphore(0, lights.Count);

            foreach (HueLight light in lights)
            {
                var thread = new Thread(() =>
                {
                    short executionNumber = 1;

                    startFlag.WaitOne();

                    foreach (HueStateJSONProperty property in queue)
                    {
                        flag++;
                        while (flag < executionNumber * nStates) { }
                        _controller.ChangeLightState(light.uniqueId, property).Wait();
                        executionNumber++;
                    }
                });
                thread.Start();
            }

            startFlag.Release(lights.Count);
        }
    }
}

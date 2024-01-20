using PhilipsHue.Collections;
using PhilipsHue.Controllers;
using PhilipsHue.EffectConfig.Creators.Classes;
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
        private EffectProxy effectProxy;
        private const string _name = "Flash";
        private const HueLightEffectKindEnum _effectType = HueLightEffectKindEnum.MULTI;
        public string Name { get { return _name; } }
        public string EffectTypeName { get { return HueLightEffectKindCollection.GetKindName(_effectType); } }

        public Flash() {
            effectProxy = new EffectProxy();
        }

        public void Perform(Dictionary<string, Bridge> dictionary, List<HueLight> lights, IEffectConfigSet config)
        {
            Queue<HueStateJSONProperty> queue = config.GetHueStateQueue();
            int interval = 0;

            if(config is FlashConfigSet)
            {
                interval = (int)((FlashConfigSet)config).TransitionTimeConfig.GetTimeInMiliseconds() / 2;
            }

            foreach (HueLight light in lights)
            {
                var t = new Thread(() =>
                {
                    var queueCopy = new Queue<HueStateJSONProperty>(queue);
                    while (queueCopy.Count > 0)
                    {
                        var state = queueCopy.Dequeue();
                        Task task = effectProxy.ChangeLightState(dictionary, light.uniqueId, state);

                        task.Wait();
                        Thread.Sleep(interval);
                    }
                });
                t.Start();
            }
        }
    }
}

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
        private static readonly Flash _flash = new Flash();
        private static readonly HueLightController _controller = HueLightController.Singleton();
        private const string _name = "Flash";
        private const HueLightEffectKindEnum _effectType = HueLightEffectKindEnum.MULTI;
        public string Name { get { return _name; } }
        public string EffectTypeName { get { return HueLightEffectKindCollection.GetKindName(_effectType); } }

        private Flash() { }

        public static Flash Singleton()
        {
            return _flash;
        }

        public async void Perform(List<HueLight> lights, IEffectConfigSet config)
        {
            //Maybe the queue logic should be done in this class instead of the config class
            Queue<HueStateJSONProperty> queue = config.GetHueStateQueue();

            //var timer = new Stopwatch();

            //timer.Start();
            //Parallel.ForEach<string>(lightIds, id =>
            //{
            //    MaxBrightnessEffect(id, list, state);
            //    MinBrightnessEffect(id, list, state);
            //});

            //var signal = new ManualResetEventSlim();

            //foreach (string id in lightIds)
            //{
            //    var thread = new Thread(async () =>
            //    {
            //        signal.Wait();
            //        await MaxBrightnessEffect(id, list, state);
            //        await MinBrightnessEffect(id, list, state);
            //    });
            //    thread.Start();
            //}
            //Console.WriteLine("GO!");
            //signal.Set();

            //Need to think how we are going to wait for the inner loop to finish before
            //going back to the outer loop
            foreach (HueStateJSONProperty c in queue)
            {
                foreach (HueLight light in lights)
                    await _controller.ChangeLightState(light.uniqueId, c);
            }

            //timer.Stop();
            //Console.WriteLine("Time 1: " + timer.Elapsed.ToString());
        }
    }
}

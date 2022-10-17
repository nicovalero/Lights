using PhilipsHue.Controllers;
using PhilipsHue.Effects.Interfaces;
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
        private const ushort _maxBrightness = 255;
        private const ushort _minBrightness = 0;
        private const string _name = "Flash";
        public string Name { get { return _name; } }

        private Flash() { }

        public static Flash Singleton()
        {
            return _flash;
        }

        public async void Perform(List<HueLight> lights, object value)
        {
            List<HueJSONBodyStateProperty> list = new List<HueJSONBodyStateProperty>();
            list.Add(HueJSONBodyStateProperty.BRI);

            HueState state = new HueState();

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

            foreach (HueLight light in lights)
            {
                await MaxBrightnessEffect(light.uniqueId, list, state);
            }

            foreach (HueLight light in lights)
            {
                await MinBrightnessEffect(light.uniqueId, list, state);
            }

            //timer.Stop();
            //Console.WriteLine("Time 1: " + timer.Elapsed.ToString());
        }

        private async Task MaxBrightnessEffect(string lightId, List<HueJSONBodyStateProperty> list, HueState state)
        {
            state.bri = _maxBrightness;
            await _controller.ChangeLightState(lightId, state, list);
        }

        private async Task MinBrightnessEffect(string lightId, List<HueJSONBodyStateProperty> list, HueState state)
        {
            state.bri = _minBrightness;
            await _controller.ChangeLightState(lightId, state, list);
        }
    }
}

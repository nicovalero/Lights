﻿using PhilipsHue.Collections;
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
using System.Threading;
using System.Threading.Tasks;

namespace PhilipsHue.Effects.Classes
{
    public class BrightnessWave : LightEffect
    {
        private static readonly BrightnessWave _flash = new BrightnessWave();
        private static readonly HueLightController _controller = HueLightController.Singleton();
        private const string _name = "Brightness Wave";
        private const HueLightEffectKindEnum _effectType = HueLightEffectKindEnum.MULTI;
        public string Name { get { return _name; } }
        public string EffectTypeName { get { return HueLightEffectKindCollection.GetKindName(_effectType); } }

        private BrightnessWave() { }

        public static BrightnessWave Singleton()
        {
            return _flash;
        }

        public void Perform(List<HueLight> lights, IEffectConfigSet config)
        {
            Queue<HueStateJSONProperty> queue = config.GetHueStateQueue();

            List<HueLight> hueLights;
            int intervalInt = 0;
            if (config is BrightnessWaveConfigSet)
            {
                BrightnessWaveConfigSet configSet = (BrightnessWaveConfigSet)config;
                hueLights = configSet.LightListConfig.LightList;
                intervalInt = (int)(configSet.IntervalTimeConfig.GetTimeInMiliseconds());
            }
            else
                hueLights = lights;

            foreach (HueStateJSONProperty c in queue)
            {
                ThreadPool.QueueUserWorkItem((state) =>
                {
                    foreach (HueLight light in hueLights)
                    {
                        var task = _controller.ChangeLightState(light.uniqueId, c);
                        task.Wait();
                        Thread.Sleep(intervalInt);
                    }
                });
            }
        }
    }
}

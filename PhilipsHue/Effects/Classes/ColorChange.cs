﻿using PhilipsHue.Collections;
using PhilipsHue.Controllers;
using PhilipsHue.EffectConfig.Creators.Interfaces;
using PhilipsHue.Effects.Interfaces;
using PhilipsHue.Models;
using PhilipsHue.Models.Classes;
using PhilipsHue.Models.Enums;
using PhilipsHue.Models.Interfaces;
using System.Collections.Generic;
using System.Threading;

namespace PhilipsHue.Effects.Classes
{
    public class ColorChange : LightEffect
    {
        private static readonly ColorChange _colorChange = new ColorChange();
        private static readonly HueLightController _controller = HueLightController.Singleton();
        private const string _name = "Color change";
        private const HueLightEffectKindEnum _effectType = HueLightEffectKindEnum.MULTI;
        public string Name { get { return _name; } }
        public string EffectTypeName { get { return HueLightEffectKindCollection.GetKindName(_effectType); } }

        private ColorChange() { }

        public static ColorChange Singleton()
        {
            return _colorChange;
        }

        public void Perform(List<HueLight> lights, IEffectConfigSet config)
        {
            foreach (HueStateJSONProperty combo in config.GetHueStateQueue())
            {
                foreach (HueLight light in lights)
                {
                    ThreadPool.QueueUserWorkItem((state) =>
                    {
                        _controller.ChangeLightState(light.uniqueId, combo);
                    });
                }
            }
        }

        public string GetName()
        {
            return _name;
        }
    }
}

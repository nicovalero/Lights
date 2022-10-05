﻿using PhilipsHueAPI.Controllers;
using PhilipsHueAPI.Effects.Interfaces;
using PhilipsHueAPI.Models.Classes;
using PhilipsHueAPI.Models.Enums;

namespace PhilipsHueAPI.Effects.Classes
{
    public class FadeIn : LightEffect
    {
        private static readonly FadeIn _fadeIn = new FadeIn();
        private static readonly HueLightController _controller = HueLightController.Singleton();

        private FadeIn() { }

        public static FadeIn Singleton()
        {
            return _fadeIn;
        }

        public void Perform(List<string> lightIds, object value = null)
        {
            List<HueJSONBodyStateProperty> list = new List<HueJSONBodyStateProperty>();
            list.Add(HueJSONBodyStateProperty.BRI);

            for (ushort brightness = 0; brightness < 256; brightness += 5)
            {
                HueState state = new HueState();
                state.bri = brightness;

                foreach(string lightId in lightIds)
                    _controller.ChangeLightState(lightId, state, list);
            }
        }
    }
}

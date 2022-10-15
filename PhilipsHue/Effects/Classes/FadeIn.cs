using PhilipsHue.Controllers;
using PhilipsHue.Effects.Interfaces;
using PhilipsHue.Models.Classes;
using PhilipsHue.Models.Enums;
using System.Collections.Generic;

namespace PhilipsHue.Effects.Classes
{
    public class FadeIn : LightEffect
    {
        private static readonly FadeIn _fadeIn = new FadeIn();
        private static readonly HueLightController _controller = HueLightController.Singleton();
        private const string _name = "Fade in";

        private FadeIn() { }

        public static FadeIn Singleton()
        {
            return _fadeIn;
        }

        public async void Perform(List<string> lightIds, object value = null)
        {
            List<HueJSONBodyStateProperty> list = new List<HueJSONBodyStateProperty>();
            list.Add(HueJSONBodyStateProperty.BRI);

            for (ushort brightness = 0; brightness < 256; brightness += 5)
            {
                HueState state = new HueState();
                state.bri = brightness;

                foreach(string lightId in lightIds)
                    await _controller.ChangeLightState(lightId, state, list);
            }
        }

        public string GetName()
        {
            return _name;
        }
    }
}

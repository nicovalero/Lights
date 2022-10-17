using PhilipsHue.Controllers;
using PhilipsHue.Effects.Interfaces;
using PhilipsHue.Models.Classes;
using PhilipsHue.Models.Enums;
using PhilipsHue.Models.Interfaces;
using System.Collections.Generic;

namespace PhilipsHue.Effects.Classes
{
    public class FadeIn : LightEffect
    {
        private static readonly FadeIn _fadeIn = new FadeIn();
        private static readonly HueLightController _controller = HueLightController.Singleton();
        private const string _name = "Fade in";
        public string Name { get { return _name; } }

        private FadeIn() { }

        public static FadeIn Singleton()
        {
            return _fadeIn;
        }

        public async void Perform(List<HueLight> lights, object value = null)
        {
            List<HueJSONBodyStateProperty> list = new List<HueJSONBodyStateProperty>();
            list.Add(HueJSONBodyStateProperty.BRI);

            for (ushort brightness = 0; brightness < 256; brightness += 5)
            {
                HueState state = new HueState();
                state.bri = brightness;

                foreach(HueLight light in lights)
                    await _controller.ChangeLightState(light.uniqueId, state, list);
            }
        }

        public string GetName()
        {
            return _name;
        }
    }
}

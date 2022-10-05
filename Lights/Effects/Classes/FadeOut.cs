using PhilipsHueAPI.Controllers;
using PhilipsHueAPI.Effects.Interfaces;
using PhilipsHueAPI.Models.Classes;
using PhilipsHueAPI.Models.Enums;

namespace PhilipsHueAPI.Effects.Classes
{
    public class FadeOut : LightEffect
    {
        private static readonly FadeOut _fadeOut = new FadeOut();
        private static readonly HueLightController _controller = HueLightController.Singleton();

        private FadeOut() { }

        public static FadeOut Singleton()
        {
            return _fadeOut;
        }

        public void Perform(List<string> lightIds, object value = null)
        {
            List<HueJSONBodyStateProperty> list = new List<HueJSONBodyStateProperty>();
            list.Add(HueJSONBodyStateProperty.BRI);

            for (ushort brightness = 255; brightness >= 0; brightness -= 5)
            {
                HueState state = new HueState();
                state.bri = brightness;

                foreach (string lightId in lightIds)
                    _controller.ChangeLightState(lightId, state, list);
            }
        }
    }
}

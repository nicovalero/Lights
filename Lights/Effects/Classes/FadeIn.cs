using PhilipsHueAPI.Controllers;
using PhilipsHueAPI.Effects.Interfaces;
using PhilipsHueAPI.Models.Classes;
using PhilipsHueAPI.Models.Enums;

namespace PhilipsHueAPI.Effects.Classes
{
    public class FadeIn : AutomaticEffectSingleLight
    {
        private static readonly FadeIn _fadeIn = new FadeIn();
        private static readonly HueLightController _controller = HueLightController.Singleton();

        private FadeIn() { }

        public static FadeIn Singleton()
        {
            return _fadeIn;
        }

        public void Perform(string LightId)
        {
            List<HueJSONBodyStateProperty> list = new List<HueJSONBodyStateProperty>();
            list.Add(HueJSONBodyStateProperty.BRI);

            for (ushort brightness = 0; brightness < 256; brightness += 5)
            {
                HueState state = new HueState();
                state.bri = brightness;

                _controller.ChangeLightState(LightId, state, list);
            }
        }
    }
}

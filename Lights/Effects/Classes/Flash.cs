using Microsoft.AspNetCore.Mvc;
using PhilipsHueAPI.Controllers;
using PhilipsHueAPI.Effects.Interfaces;
using PhilipsHueAPI.Models.Classes;
using PhilipsHueAPI.Models.Enums;

namespace PhilipsHueAPI.Effects.Classes
{
    public class Flash : AutomaticEffectSingleLight
    {
        private static readonly Flash _flash = new Flash();
        private static readonly HueLightController _controller = HueLightController.Singleton();
        private const ushort _maxBrightness = 255;
        private const ushort _minBrightness = 0;

        private Flash() { }

        public static Flash Singleton()
        {
            return _flash;
        }

        public void Perform(string lightId)
        {
            List<HueJSONBodyStateProperty> list = new List<HueJSONBodyStateProperty>();
            list.Add(HueJSONBodyStateProperty.BRI);

            HueState state = new HueState();

            state.bri = _maxBrightness;
            _controller.ChangeLightState(lightId, state, list);

            Thread.Sleep(50);

            state.bri = _minBrightness;
            _controller.ChangeLightState(lightId, state, list);
        }
    }
}

using PhilipsHue.Controllers;
using PhilipsHue.Effects.Interfaces;
using PhilipsHue.Models.Classes;
using PhilipsHue.Models.Enums;
using System.Collections.Generic;

namespace PhilipsHue.Effects.Classes
{
    public class ColorChange: LightEffect
    {
        private static readonly ColorChange _colorChange = new ColorChange();
        private static readonly HueLightController _controller = HueLightController.Singleton();

        private ColorChange() { }

        public static ColorChange Singleton()
        {
            return _colorChange;
        }

        public void Perform(List<string> lightIds, object value)
        {
            List<HueJSONBodyStateProperty> list = new List<HueJSONBodyStateProperty>();
            list.Add(HueJSONBodyStateProperty.HUE);

            HueState state = new HueState();
            state.hue = (ushort) value;

            foreach(string lightId in lightIds)
                _controller.ChangeLightState(lightId, state, list);
        }
    }
}

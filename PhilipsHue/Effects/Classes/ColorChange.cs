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
        private const string _name = "Color change";
        public string Name { get { return _name; } }

        private ColorChange() { }

        public static ColorChange Singleton()
        {
            return _colorChange;
        }

        public async void Perform(List<string> lightIds, object value)
        {
            List<HueJSONBodyStateProperty> list = new List<HueJSONBodyStateProperty>();
            list.Add(HueJSONBodyStateProperty.HUE);

            HueState state = new HueState();
            state.hue = (ushort) value;

            foreach(string lightId in lightIds)
                await _controller.ChangeLightState(lightId, state, list);
        }

        public string GetName()
        {
            return _name;
        }
    }
}

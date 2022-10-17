using PhilipsHue.Controllers;
using PhilipsHue.Effects.Interfaces;
using PhilipsHue.Models.Classes;
using PhilipsHue.Models.Enums;
using PhilipsHue.Models.Interfaces;
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

        public async void Perform(List<HueLight> lights, object value)
        {
            List<HueJSONBodyStateProperty> list = new List<HueJSONBodyStateProperty>();
            list.Add(HueJSONBodyStateProperty.HUE);

            HueState state = new HueState();
            state.hue = (ushort) value;

            foreach(HueLight light in lights)
                await _controller.ChangeLightState(light.uniqueId, state, list);
        }

        public string GetName()
        {
            return _name;
        }
    }
}

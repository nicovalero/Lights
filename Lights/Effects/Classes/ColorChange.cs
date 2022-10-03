using PhilipsHueAPI.Controllers;
using PhilipsHueAPI.Effects.Interfaces;
using PhilipsHueAPI.Models.Classes;
using PhilipsHueAPI.Models.Enums;

namespace PhilipsHueAPI.Effects.Classes
{
    public class ColorChange: ValuedEffectSingleLight
    {
        private static readonly ColorChange _colorChange = new ColorChange();
        private static readonly HueLightController _controller = HueLightController.Singleton();

        private ColorChange() { }

        public static ColorChange Singleton()
        {
            return _colorChange;
        }

        public void Perform(string LightId, object value)
        {
            List<HueJSONBodyStateProperty> list = new List<HueJSONBodyStateProperty>();
            list.Add(HueJSONBodyStateProperty.HUE);

            HueState state = new HueState();
            state.hue = (ushort) value;

            _controller.ChangeLightState(LightId, state, list);
        }
    }
}

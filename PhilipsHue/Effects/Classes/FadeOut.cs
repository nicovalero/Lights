using PhilipsHue.Collections;
using PhilipsHue.Controllers;
using PhilipsHue.Effects.Interfaces;
using PhilipsHue.Models.Classes;
using PhilipsHue.Models.Enums;
using PhilipsHue.Models.Interfaces;
using System.Collections.Generic;

namespace PhilipsHue.Effects.Classes
{
    public class FadeOut : LightEffect
    {
        private static readonly FadeOut _fadeOut = new FadeOut();
        private static readonly HueLightController _controller = HueLightController.Singleton();
        private const string _name = "Fade out";
        private const HueLightEffectKindEnum _effectType = HueLightEffectKindEnum.MULTI;
        public string Name { get { return _name; } }
        public string EffectTypeName { get { return HueLightEffectKindCollection.GetKindName(_effectType); } }

        private FadeOut() { }

        public static FadeOut Singleton()
        {
            return _fadeOut;
        }

        public async void Perform(List<HueLight> lights, object value = null)
        {
            List<HueJSONBodyStateProperty> list = new List<HueJSONBodyStateProperty>();
            list.Add(HueJSONBodyStateProperty.BRI);

            for (ushort brightness = 255; brightness >= 0; brightness -= 5)
            {
                HueState state = new HueState();
                state.bri = brightness;

                foreach (HueLight light in lights)
                    await _controller.ChangeLightState(light.uniqueId, state, list);
            }
        }

        public string GetName()
        {
            return _name;
        }
    }
}

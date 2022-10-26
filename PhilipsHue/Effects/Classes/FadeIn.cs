using PhilipsHue.Collections;
using PhilipsHue.Controllers;
using PhilipsHue.Effects.Interfaces;
using PhilipsHue.Models.Classes;
using PhilipsHue.Models.Enums;
using PhilipsHue.Models.Interfaces;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace PhilipsHue.Effects.Classes
{
    public struct FadeInConfiguration
    {
        public byte InitialBrightness { get; set; }
        public byte FinalBrightness { get; set; }
        public ushort InitialSpeed { get; set; }
        public ushort IntervalSpeed { get; set; }

        public FadeInConfiguration(byte initialBrightness, byte finalBrightness, ushort initialSpeed, ushort intervalSpeed)
        {
            InitialBrightness = initialBrightness;
            FinalBrightness = finalBrightness;
            InitialSpeed = initialSpeed;
            IntervalSpeed = intervalSpeed;
        }
        public static bool operator ==(FadeInConfiguration key1, FadeInConfiguration key2)
        {
            return (key1.InitialBrightness == key2.InitialBrightness && key1.FinalBrightness == key2.FinalBrightness
                && key1.InitialSpeed == key2.InitialSpeed && key1.IntervalSpeed == key2.IntervalSpeed);
        }

        public static bool operator !=(FadeInConfiguration key1, FadeInConfiguration key2)
        {
            return !(key1.InitialBrightness == key2.InitialBrightness && key1.FinalBrightness == key2.FinalBrightness
                && key1.InitialSpeed == key2.InitialSpeed && key1.IntervalSpeed == key2.IntervalSpeed);
        }
    }

    public class FadeIn : LightEffect
    {
        private static readonly FadeIn _fadeIn = new FadeIn();
        private static readonly HueLightController _controller = HueLightController.Singleton();
        private const string _name = "Fade in";
        private const HueLightEffectKindEnum _effectType = HueLightEffectKindEnum.MULTI;
        public string Name { get { return _name; } }
        public string EffectTypeName { get { return HueLightEffectKindCollection.GetKindName(_effectType); } }

        private FadeIn() { }

        public static FadeIn Singleton()
        {
            return _fadeIn;
        }

        public async void Perform(List<HueLight> lights, object config = null)
        {
            //This is in place temporarily until I develop the config panel
            //in the UI.
            if(config == null)
            {
                FadeInConfiguration configuration = new FadeInConfiguration((byte)0, (byte)255, (ushort) 400, (ushort) 0);
                config = configuration;
            }

            if (config is FadeInConfiguration)
            {
                FadeInConfiguration fadeInConfiguration = (FadeInConfiguration)config;
                List<HueJSONBodyStateProperty> list = new List<HueJSONBodyStateProperty>();
                list.Add(HueJSONBodyStateProperty.BRI);

                HueState state = new HueState();
                state.bri = fadeInConfiguration.InitialBrightness;

                foreach (HueLight light in lights)
                    ChangeLightState(light, state, list).Wait();
                Thread.Sleep(fadeInConfiguration.InitialSpeed);

                ushort brightness = (ushort)(fadeInConfiguration.InitialBrightness + 10);

                for (; brightness <= fadeInConfiguration.FinalBrightness; brightness += 10)
                {
                    state.bri = brightness;

                    foreach (HueLight light in lights)
                        await ChangeLightState(light, state, list);

                    Thread.Sleep(fadeInConfiguration.IntervalSpeed);
                }
            }
        }

        private async Task ChangeLightState(HueLight light, HueState state, List<HueJSONBodyStateProperty> list)
        {
            await _controller.ChangeLightState(light.uniqueId, state, list);
        }

        public string GetName()
        {
            return _name;
        }
    }
}

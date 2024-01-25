using Nanoleaf.EffectConfig.Enums;
using Nanoleaf.EffectConfig.Products.Interfaces;

namespace Nanoleaf.EffectConfig.Parts.Classes
{
    public class BrightnessConfig : IEffectPropertyConfig
    {
        private readonly string _jsonProperty = JSONBodyStateProperty.BRIGHTNESS;
        private byte _value;
        public string JsonProperty { get => _jsonProperty; }
        public object Value { get => _value; set { _value = (byte)value; } }

        public BrightnessConfig(byte value)
        {
            _value = value;
        }
    }
}

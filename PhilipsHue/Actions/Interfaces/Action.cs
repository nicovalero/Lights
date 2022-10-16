using PhilipsHue.Effects.Interfaces;

namespace PhilipsHue.Actions.Interfaces
{
    public interface LightEffectAction
    {
        void Perform();
        LightEffect GetEffect();
    }
}

using System.Collections.Generic;

namespace PhilipsHue.Effects.Interfaces
{
    public interface LightEffect
    {
        void Perform(List<string> lightIds, object value);
    }
}

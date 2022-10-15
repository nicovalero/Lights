using System.Collections.Generic;
using System.Threading.Tasks;

namespace PhilipsHue.Effects.Interfaces
{
    public interface LightEffect
    {
        void Perform(List<string> lightIds, object value);
        string GetName();
    }
}

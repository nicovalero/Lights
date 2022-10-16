using System.Collections.Generic;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace PhilipsHue.Effects.Interfaces
{
    public interface LightEffect
    {
        string Name { get; }
        void Perform(List<string> lightIds, object value);
    }
}

using Nanoleaf.Devices.Classes;
using Nanoleaf.Devices.Enums;
using Nanoleaf.Devices.Interfaces;
using Newtonsoft.Json;

namespace Nanoleaf.Devices.Factories
{
    internal class ShapesFactory
    {
        internal IShapesPanel CreateShapesPanel(string jsonString)
        {
            var shapesPanel = JsonConvert.DeserializeObject<ShapesPanel>(jsonString);

            return shapesPanel;
        }
    }
}

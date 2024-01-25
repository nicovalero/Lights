using Control.Models.Classes.ViewEffects;
using Control.Models.Interfaces;
using Nanoleaf.Devices.Interfaces;
using PhilipsHue.Models.Interfaces;

namespace Control.Factories
{
    public class ViewLightFactory
    {
        public ViewLightFactory()
        {
        }

        public IViewLight ConstructFromHueLight(HueLight light)
        {
            return new PhilipsHueViewLight(light.uniqueId, light.name, light.type);
        }

        public IViewLight ConstructFromNanoleafLight(IShapesPanel light)
        {
            return new NanoleafViewLight(light.GetPanelID());
        }
    }
}

using Control.Enums;
using Control.Models.Classes;
using Control.Models.Classes.ViewEffects;
using Control.Models.Interfaces;
using PhilipsHue.Collections;
using PhilipsHue.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Control.Factories
{
    public class ViewLightFactory
    {
        public ViewLightFactory()
        {
        }

        public IViewLight Construct(AvailableViewLights availableLights, HueLight light)
        {
            IViewLight viewLight = null;
            switch (availableLights)
            {
                case AvailableViewLights.PhilipsHue:
                    viewLight = new PhilipsHueViewLight(light.uniqueId, light.name, light.type);
                    break;
            }

            return viewLight;
        }
    }
}

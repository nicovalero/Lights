using Control.Enums;
using Control.Models.Classes;
using Control.Models.Classes.ViewEffects;
using Control.Models.Interfaces;
using PhilipsHue.Collections;
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

        public IViewLight Construct(AvailableViewLights availableLights, string ID)
        {
            IViewLight light = null;
            switch (availableLights)
            {
                case AvailableViewLights.Nanoleaf:
                    light = new NanoleafViewLight(ID);
                    break;
                case AvailableViewLights.PhilipsHue:
                    light = new PhilipsHueViewLight(ID);
                    break;
            }

            return light;
        }
    }
}

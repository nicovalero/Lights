using Nanoleaf.Devices.Interfaces;
using Nanoleaf.EffectConfig.Parts.Interfaces;
using System.Collections.Generic;

namespace Nanoleaf.EffectConfig.Parts.Classes
{
    public class NanoleafLightListConfig : INanoleafLightListConfig
    {
        private List<IShapesPanel> _lightList;
        public List<IShapesPanel> LightList { get { return _lightList; } set { _lightList = value; } }

        public NanoleafLightListConfig(List<IShapesPanel> lightList)
        {
            _lightList = lightList;
        }
    }
}

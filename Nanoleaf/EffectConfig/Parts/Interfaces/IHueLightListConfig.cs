using Nanoleaf.Devices.Interfaces;
using System.Collections.Generic;

namespace Nanoleaf.EffectConfig.Parts.Interfaces
{
    public interface INanoleafLightListConfig
    {
        List<IShapesPanel> LightList { get; set; }
    }
}

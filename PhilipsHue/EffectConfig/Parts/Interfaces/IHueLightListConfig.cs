using PhilipsHue.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhilipsHue.EffectConfig.Parts.Interfaces
{
    public interface IHueLightListConfig
    {
        List<HueLight> GetList();
    }
}

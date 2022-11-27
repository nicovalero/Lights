using PhilipsHue.EffectConfig.Parts.Interfaces;
using PhilipsHue.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhilipsHue.EffectConfig.Parts.Classes
{
    public class HueLightListConfig : IHueLightListConfig
    {
        private List<HueLight> _lightList;
        public List<HueLight> LightList { get { return _lightList; } set { _lightList = value; } }

        public HueLightListConfig(List<HueLight> lightList)
        {
            _lightList = lightList;
        }
    }
}

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
        public List<HueLight> SetList { set { _lightList = value; } }
        public List<HueLight> GetList()
        {
            return _lightList;
        }

        public HueLightListConfig(List<HueLight> lightList)
        {
            _lightList = lightList;
        }
    }
}

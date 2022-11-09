using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UI.Models.Structs;
using UI.Models.ViewModel_Config_Sets.Interfaces;

namespace UI.Models.ViewModel_Config_Sets.Classes
{
    internal class FadeOutConfig_VMSet : IConfigVMSet
    {
        private BrightnessConfig_ViewModel _brightnessLevel;
        public BrightnessConfig_ViewModel BrightnessLevel { get { return _brightnessLevel; } set { _brightnessLevel = value; } }

        public FadeOutConfig_VMSet(BrightnessConfig_ViewModel brightnessLevel)
        {
            _brightnessLevel = brightnessLevel;
        }

        public List<object> GetConfigViewModels()
        {
            List<object> list = new List<object>();
            list.Add(BrightnessLevel);
            return list;
        }
    }
}

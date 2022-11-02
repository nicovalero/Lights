using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UI.Models.Structs;
using UI.Models.ViewModel_Config_Sets.Interfaces;

namespace UI.Models.ViewModel_Config_Sets.Classes
{
    internal class FlashConfig_VMSet : IConfigVMSet
    {
        private BrightnessConfig_ViewModel _firstBrightnessLevel;
        private BrightnessConfig_ViewModel _secondBrightnessLevel;
        public BrightnessConfig_ViewModel FirstBrightnessLevel { get { return _firstBrightnessLevel; } set { _firstBrightnessLevel = value; } }
        public BrightnessConfig_ViewModel SecondBrightnessLevel { get { return _secondBrightnessLevel; } set { _secondBrightnessLevel = value; } }

        public FlashConfig_VMSet(BrightnessConfig_ViewModel firstBrightnessLevel, BrightnessConfig_ViewModel secondBrightnessLevel)
        {
            _firstBrightnessLevel = firstBrightnessLevel;
            _secondBrightnessLevel = secondBrightnessLevel;
        }

        public List<object> GetConfigViewModels()
        {
            List<object> list = new List<object>();
            list.Add(FirstBrightnessLevel);
            list.Add(SecondBrightnessLevel);
            return list;
        }
    }
}

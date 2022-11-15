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

        private TransitionTimeConfig_ViewModel _transitionTime;
        public TransitionTimeConfig_ViewModel TransitionTime { get { return _transitionTime; } set { _transitionTime = value; } }

        public FlashConfig_VMSet(BrightnessConfig_ViewModel firstBrightnessLevel, BrightnessConfig_ViewModel secondBrightnessLevel,
            TransitionTimeConfig_ViewModel transitionTimeViewModel)
        {
            _firstBrightnessLevel = firstBrightnessLevel;
            _secondBrightnessLevel = secondBrightnessLevel;
            _transitionTime = transitionTimeViewModel;
        }

        public List<object> GetConfigViewModels()
        {
            List<object> list = new List<object>();
            list.Add(FirstBrightnessLevel);
            list.Add(SecondBrightnessLevel);
            list.Add(TransitionTime);
            return list;
        }
    }
}

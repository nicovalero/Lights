using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UI.Models.Structs;
using UI.Models.ViewModel_Config_Sets.Interfaces;

namespace UI.Models.ViewModel_Config_Sets.Classes
{
    internal class FadeInConfig_VMSet : IConfigVMSet
    {
        private BrightnessConfig_ViewModel _brightnessLevel;
        public BrightnessConfig_ViewModel BrightnessLevel { get { return _brightnessLevel; } set { _brightnessLevel = value; } }

        private TransitionTimeConfig_ViewModel _transitionTime;
        public TransitionTimeConfig_ViewModel TransitionTime { get { return _transitionTime; } set { _transitionTime = value; } }

        public FadeInConfig_VMSet(BrightnessConfig_ViewModel brightnessLevel, TransitionTimeConfig_ViewModel transitionTimeViewModel)
        {
            _brightnessLevel = brightnessLevel;
            _transitionTime = transitionTimeViewModel;
        }

        public List<object> GetConfigViewModels()
        {
            List<object> list = new List<object>();
            list.Add(BrightnessLevel);
            list.Add(TransitionTime);
            return list;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Navigation;
using UI.Models.Structs;
using UI.Models.ViewModel_Config_Sets.Interfaces;

namespace UI.Models.ViewModel_Config_Sets.Classes
{
    internal class BrightnessWaveConfig_VMSet : IConfigVMSet
    {
        private BrightnessConfig_ViewModel _brightnessLevel;
        public BrightnessConfig_ViewModel BrightnessLevel { get { return _brightnessLevel; } set { _brightnessLevel = value; } }

        private LightListConfig_ViewModel _lightList;
        public LightListConfig_ViewModel LightList { get { return _lightList; } set { _lightList = value; } }

        private TransitionTimeConfig_ViewModel _transitionTime;
        public TransitionTimeConfig_ViewModel TransitionTime { get { return _transitionTime; } set { _transitionTime = value; } }

        private TransitionTimeConfig_ViewModel _intervalTime;
        public TransitionTimeConfig_ViewModel IntervalTime { get { return _intervalTime; } set { _intervalTime = value; } }

        public BrightnessWaveConfig_VMSet()
        {
        }

        public BrightnessWaveConfig_VMSet(BrightnessConfig_ViewModel brightnessViewModel, LightListConfig_ViewModel lightsViewModel,
            TransitionTimeConfig_ViewModel transitionTimeViewModel, TransitionTimeConfig_ViewModel intervalTimeViewModel)
        {
            _brightnessLevel = brightnessViewModel;
            _lightList = lightsViewModel;
            _transitionTime = transitionTimeViewModel;
            _intervalTime = intervalTimeViewModel;
        }

        public List<object> GetConfigViewModels()
        {
            List<object> models = new List<object>();
            models.Add(BrightnessLevel);
            models.Add(TransitionTime);
            models.Add(LightList);
            models.Add(IntervalTime);
            return models;
        }
    }
}

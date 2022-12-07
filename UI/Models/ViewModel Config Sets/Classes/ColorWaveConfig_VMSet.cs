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
    internal class ColorWaveConfig_VMSet : IConfigVMSet, ILightListConfig
    {
        private ColorConfig_ViewModel _finalColor;
        public ColorConfig_ViewModel FinalColor { get { return _finalColor; } set { _finalColor = value; } }

        private LightListConfig_ViewModel _lightList;
        public LightListConfig_ViewModel LightList { get { return _lightList; } set { _lightList = value; } }

        private TransitionTimeConfig_ViewModel _transitionTime;
        public TransitionTimeConfig_ViewModel TransitionTime { get { return _transitionTime; } set { _transitionTime = value; } }

        private TransitionTimeConfig_ViewModel _intervalTime;
        public TransitionTimeConfig_ViewModel IntervalTime { get { return _intervalTime; } set { _intervalTime = value; } }

        public ColorWaveConfig_VMSet()
        {
        }

        public ColorWaveConfig_VMSet(ColorConfig_ViewModel colorViewModel, LightListConfig_ViewModel lightsViewModel,
            TransitionTimeConfig_ViewModel transitionTimeViewModel, TransitionTimeConfig_ViewModel intervalTimeViewModel)
        {
            _finalColor = colorViewModel;
            _lightList = lightsViewModel;
            _transitionTime = transitionTimeViewModel;
            _intervalTime = intervalTimeViewModel;
        }

        public List<object> GetConfigViewModels()
        {
            List<object> models = new List<object>();
            models.Add(FinalColor);
            models.Add(TransitionTime);
            models.Add(LightList);
            models.Add(IntervalTime);
            return models;
        }

        public LightListConfig_ViewModel GetLightListConfig()
        {
            return LightList;
        }

        public void SetLightListConfig(LightListConfig_ViewModel config)
        {
            LightList = config;
        }
    }
}

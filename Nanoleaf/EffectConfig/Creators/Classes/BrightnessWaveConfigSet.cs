using Nanoleaf.EffectConfig.Creators.Interfaces;
using Nanoleaf.EffectConfig.Enums;
using Nanoleaf.EffectConfig.Parts.Classes;
using Nanoleaf.EffectConfig.Parts.Interfaces;
using Nanoleaf.EffectConfig.Products.Interfaces;
using Nanoleaf.Network.Classes;
using Nanoleaf.Network.Factories;
using Nanoleaf.Network.Structs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.TimeZoneInfo;

namespace Nanoleaf.EffectConfig.Creators.Classes
{
    public class BrightnessWaveConfigSet : IEffectConfigSet
    {
        private BrightnessConfig _brightnessConfig;
        private INanoleafLightListConfig _lightListConfig;
        private IEffectPropertyConfig _transitionTimeConfig;
        private ITimeConfig _intervalTimeConfig;
        private Queue<StateJSONProperty> _DeviceStateQueue;
        
        public BrightnessConfig BrightnessConfig { get => _brightnessConfig; set => _brightnessConfig = value; }
        public INanoleafLightListConfig LightListConfig { get => _lightListConfig; set => _lightListConfig = value; }
        public IEffectPropertyConfig TransitionTimeConfig { get => _transitionTimeConfig; set => _transitionTimeConfig = value; }
        public ITimeConfig IntervalTimeConfig { get => _intervalTimeConfig; set => _intervalTimeConfig = value; }

        public BrightnessWaveConfigSet(byte firstBrightnessValue, IEffectPropertyConfig transitionConfig,
            INanoleafLightListConfig listConfig, ITimeConfig intervalTimeConfig)
        {
            _brightnessConfig = new BrightnessConfig(firstBrightnessValue);
            _transitionTimeConfig = transitionConfig;
            _lightListConfig = listConfig;
            _DeviceStateQueue = new Queue<StateJSONProperty>();
            _intervalTimeConfig = intervalTimeConfig;
        }

        private void RefreshQueue()
        {
            _DeviceStateQueue.Clear();
            List<IEffectPropertyConfig> list = new List<IEffectPropertyConfig>();

            list.Add(BrightnessConfig);
            list.Add(TransitionTimeConfig);
            StateJSONProperty state = StateJSONPropertyFactory.CreateFromConfigList(list);

            _DeviceStateQueue.Enqueue(state);
        }

        public Queue<StateJSONProperty> GetDeviceStateQueue()
        {
            RefreshQueue();
            return _DeviceStateQueue;
        }
    }
}

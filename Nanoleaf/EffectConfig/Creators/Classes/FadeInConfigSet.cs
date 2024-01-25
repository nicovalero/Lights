using Nanoleaf.EffectConfig.Creators.Interfaces;
using Nanoleaf.EffectConfig.Parts.Classes;
using Nanoleaf.EffectConfig.Products.Interfaces;
using Nanoleaf.EffectConfig.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.TimeZoneInfo;
using Nanoleaf.Network.Structs;
using Nanoleaf.Network.Factories;

namespace Nanoleaf.EffectConfig.Creators.Classes
{
    public class FadeInConfigSet : IEffectConfigSet
    {
        private BrightnessConfig _brightnessConfig;
        private TransitionTimeConfig _transitionTimeConfig;
        private Queue<StateJSONProperty> _DeviceStateQueue;
        public BrightnessConfig BrightnessConfig { get => _brightnessConfig; set => _brightnessConfig = value; }
        public TransitionTimeConfig TransitionTimeConfig { get => _transitionTimeConfig; set => _transitionTimeConfig = value; }

        public FadeInConfigSet(byte firstBrightnessValue, uint transitionTime)
        {
            _brightnessConfig = new BrightnessConfig(firstBrightnessValue);
            _transitionTimeConfig = new TransitionTimeConfig(transitionTime);
            _DeviceStateQueue = new Queue<StateJSONProperty>();
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

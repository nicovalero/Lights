using Nanoleaf.EffectConfig.Creators.Interfaces;
using Nanoleaf.EffectConfig.Parts.Classes;
using Nanoleaf.EffectConfig.Products.Interfaces;
using Nanoleaf.EffectConfig.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nanoleaf.Network.Structs;
using Nanoleaf.Network.Factories;

namespace Nanoleaf.EffectConfig.Creators.Classes
{
    public class FlashConfigSet: IEffectConfigSet
    {
        private BrightnessConfig _finalBrightnessConfig;
        private BrightnessConfig _initialBrightnessConfig;
        private TransitionTimeConfig _transitionTimeConfig;
        private Queue<StateJSONProperty> _DeviceStateQueue;
        public BrightnessConfig FinalBrightnessConfig { get => _finalBrightnessConfig; set => _finalBrightnessConfig = value; }
        public BrightnessConfig InitialBrightnessConfig { get => _initialBrightnessConfig; set => _initialBrightnessConfig = value; }
        public TransitionTimeConfig TransitionTimeConfig { get => _transitionTimeConfig; set => _transitionTimeConfig = value; }

        public FlashConfigSet(byte finalBrightnessValue, byte initialBrightnessValue, uint transitionTime)
        {
            _finalBrightnessConfig = new BrightnessConfig(finalBrightnessValue);
            _initialBrightnessConfig = new BrightnessConfig(initialBrightnessValue);
            _transitionTimeConfig = new TransitionTimeConfig(transitionTime);
            _DeviceStateQueue = new Queue<StateJSONProperty>();
        }

        private void RefreshQueue()
        {
            _DeviceStateQueue.Clear();
            List<IEffectPropertyConfig> list = new List<IEffectPropertyConfig>();

            list.Add(InitialBrightnessConfig);
            list.Add(TransitionTimeConfig);
            StateJSONProperty state = StateJSONPropertyFactory.CreateFromConfigList(list);
            _DeviceStateQueue.Enqueue(state);

            list.Clear();
            list.Add(FinalBrightnessConfig);
            list.Add(TransitionTimeConfig);
            state = StateJSONPropertyFactory.CreateFromConfigList(list);
            _DeviceStateQueue.Enqueue(state);
        }

        public Queue<StateJSONProperty> GetDeviceStateQueue()
        {
            RefreshQueue();
            return _DeviceStateQueue;
        }
    }
}

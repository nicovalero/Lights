using Nanoleaf.EffectConfig.Products.Classes;
using Nanoleaf.EffectConfig.Enums;
using System.Collections.Generic;
using System.Drawing;
using Nanoleaf.EffectConfig.Creators.Interfaces;
using Nanoleaf.EffectConfig.Products.Interfaces;
using System.Linq;
using Nanoleaf.EffectConfig.Parts.Classes;
using Nanoleaf.EffectConfig.Parts.Interfaces;
using Nanoleaf.Network.Structs;
using Nanoleaf.Network.Factories;

namespace Nanoleaf.EffectConfig.Creators.Classes
{
    public class TurnOnConfigSet : IEffectConfigSet
    {
        private TurnOnOffConfig _turnOnConfig;
        private Queue<StateJSONProperty> _DeviceStateQueue;
        public TurnOnOffConfig TurnOnConfig { get => _turnOnConfig; set => _turnOnConfig = value; }   

        public TurnOnConfigSet()
        {
            _turnOnConfig = new TurnOnOffConfig(true);
            _DeviceStateQueue = new Queue<StateJSONProperty>();
        }

        private void RefreshQueue()
        {
            _DeviceStateQueue.Clear();
            List<IEffectPropertyConfig> list = new List<IEffectPropertyConfig>();

            list.Add(TurnOnConfig);
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
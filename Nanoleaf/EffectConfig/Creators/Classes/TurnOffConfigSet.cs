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
    public class TurnOffConfigSet : IEffectConfigSet, IColorExchangeConfigSet
    {
        private readonly ColorConfig _finalColor;
        private TurnOnOffConfig _turnOffConfig;
        private Queue<StateJSONProperty> _DeviceStateQueue;
        public TurnOnOffConfig TurnOffConfig { get => _turnOffConfig; set => _turnOffConfig = value; }   

        public TurnOffConfigSet(Color color)
        {
            _turnOffConfig = new TurnOnOffConfig(false);
            _DeviceStateQueue = new Queue<StateJSONProperty>();
            _finalColor = new ColorConfig(color);
        }

        private void RefreshQueue()
        {
            _DeviceStateQueue.Clear();
            List<IEffectPropertyConfig> list = new List<IEffectPropertyConfig>();

            list.Add(TurnOffConfig);
            StateJSONProperty state = StateJSONPropertyFactory.CreateFromConfigList(list);
            _DeviceStateQueue.Enqueue(state);
        }

        public Queue<StateJSONProperty> GetDeviceStateQueue()
        {
            RefreshQueue();
            return _DeviceStateQueue;
        }

        public Color GetRGBColor()
        {
            return _finalColor.RGBColor;
        }
    }
}
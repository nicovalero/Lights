using Nanoleaf.EffectConfig.Creators.Interfaces;
using Nanoleaf.EffectConfig.Parts.Interfaces;
using Nanoleaf.EffectConfig.Products.Classes;
using Nanoleaf.EffectConfig.Products.Interfaces;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.TimeZoneInfo;
using Nanoleaf.Network.Structs;
using Nanoleaf.Network.Factories;

namespace Nanoleaf.EffectConfig.Creators.Classes
{
    public class ColorWaveConfigSet : IEffectConfigSet
    {
        private ColorConfig _colorConfig;
        private INanoleafLightListConfig _lightListConfig;
        private ITimeConfig _transitionTimeConfig;
        private ITimeConfig _intervalTimeConfig;
        private Queue<StateJSONProperty> _DeviceStateQueue;

        public ColorConfig ColorConfig { get => _colorConfig; set => _colorConfig = value; }
        public INanoleafLightListConfig LightListConfig { get => _lightListConfig; set => _lightListConfig = value; }
        public ITimeConfig TransitionTimeConfig { get => _transitionTimeConfig; set => _transitionTimeConfig = value; }
        public ITimeConfig IntervalTimeConfig { get => _intervalTimeConfig; set => _intervalTimeConfig = value; }

        public ColorWaveConfigSet(Color newValue, ITimeConfig transitionConfig,
            INanoleafLightListConfig listConfig, ITimeConfig intervalTimeConfig)
        {
            _colorConfig = GetFinalColor(newValue);
            _transitionTimeConfig = transitionConfig;
            _lightListConfig = listConfig;
            _DeviceStateQueue = new Queue<StateJSONProperty>();
            _intervalTimeConfig = intervalTimeConfig;
        }

        public ColorConfig GetFinalColor(Color newValue)
        {
            return new ColorConfig(newValue);
        }

        private void RefreshQueue()
        {
            _DeviceStateQueue.Clear();
            List<IEffectPropertyConfig> list = new List<IEffectPropertyConfig>();

            list.Add(ColorConfig);
            if(TransitionTimeConfig is IEffectPropertyConfig config)
                list.Add(config);
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

using Nanoleaf.EffectConfig.Products.Classes;
using Nanoleaf.EffectConfig.Enums;
using System.Collections.Generic;
using System.Drawing;
using Nanoleaf.EffectConfig.Creators.Interfaces;
using Nanoleaf.EffectConfig.Products.Interfaces;
using System.Linq;
using Nanoleaf.EffectConfig.Parts.Classes;
using Nanoleaf.Network.Structs;
using Nanoleaf.Network.Factories;

namespace Nanoleaf.EffectConfig.Creators.Classes
{
    public class ColorChangeConfigSet : IEffectConfigSet, IColorExchangeConfigSet
    {
        private ColorConfig _finalColor;
        private TransitionTimeConfig _transitionTimeConfig;
        private Queue<StateJSONProperty> _DeviceStateQueue;
        public ColorConfig FinalColor
        {
            get { return _finalColor; }
            set { _finalColor = value; }
        }
        public TransitionTimeConfig TransitionTimeConfig { get => _transitionTimeConfig; set => _transitionTimeConfig = value; }

        public ColorChangeConfigSet(Color newValue, uint transitionTime)
        {
            FillFinalColor(newValue);
            _DeviceStateQueue = new Queue<StateJSONProperty>();
            _transitionTimeConfig = new TransitionTimeConfig(transitionTime);
        }

        public void FillFinalColor(Color newValue)
        {
            _finalColor = new ColorConfig(newValue);
        }

        private void RefreshQueue()
        {
            _DeviceStateQueue.Clear();
            List<IEffectPropertyConfig> list = new List<IEffectPropertyConfig>();

            list.Add(FinalColor);
            list.Add(TransitionTimeConfig);
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
            return FinalColor.RGBColor;
        }

        public uint GetTransitionTimeInMilliseconds()
        {
            return TransitionTimeConfig.GetTimeInMiliseconds();
        }
    }
}
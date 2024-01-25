using Nanoleaf.EffectConfig.Enums;
using Nanoleaf.EffectConfig.Products.Interfaces;
using Nanoleaf.Network.Classes;
using Nanoleaf.Network.Structs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nanoleaf.Network.Factories
{
    internal static class StateJSONPropertyFactory
    {
        internal static StateJSONProperty CreateFromConfigList(List<IEffectPropertyConfig> properties)
        {
            DeviceState state = new DeviceState();
            HashSet<string> set = new HashSet<string>();

            foreach (IEffectPropertyConfig property in properties)
            {
                switch (property.JsonProperty)
                {
                    case JSONBodyStateProperty.BRIGHTNESS:
                        if (property.Value is byte)
                        {
                            if (!set.Contains(property.JsonProperty))
                                set.Add(property.JsonProperty);
                            state.brightness = (byte)property.Value;
                        }
                        break;
                    //case JSONBodyStateProperty.TRANSITIONTIME:
                    //    if (property.Value is uint)
                    //    {
                    //        if (!set.Contains(property.JsonProperty))
                    //            set.Add(property.JsonProperty);
                    //        state.transitiontime = (uint)property.Value;
                    //    }
                    //    break;
                    default:
                        break;
                }
            }

            StateJSONProperty StateJSONProperty = new StateJSONProperty(set, state);

            return StateJSONProperty;
        }
    }
}

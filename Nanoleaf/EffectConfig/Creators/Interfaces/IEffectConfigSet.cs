using Nanoleaf.Network.Structs;
using System.Collections.Generic;

namespace Nanoleaf.EffectConfig.Creators.Interfaces
{
    public interface IEffectConfigSet
    {
        Queue<StateJSONProperty> GetDeviceStateQueue();
    }
}

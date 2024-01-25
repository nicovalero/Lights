using Nanoleaf.EffectConfig.Enums;
using Nanoleaf.Network.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nanoleaf.Network.Structs
{
    public struct StateJSONProperty
    {
        private HashSet<string> _jsonProperties;
        private DeviceState _state;
        internal HashSet<string> JsonProperties { get { return _jsonProperties; } set { _jsonProperties = value; } }
        public DeviceState State { get { return _state; } set { _state = value; } }

        internal StateJSONProperty(HashSet<string> properties, DeviceState state)
        {
            _state = state;
            _jsonProperties = properties;
        }

        public static bool operator ==(StateJSONProperty key1, StateJSONProperty key2)
        {
            return (key1._jsonProperties == key2._jsonProperties && key1._state != key2._state);
        }

        public static bool operator !=(StateJSONProperty key1, StateJSONProperty key2)
        {
            return !(key1._jsonProperties == key2._jsonProperties && key1._state != key2._state);
        }
    }
}

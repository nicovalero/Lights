using PhilipsHue.Models.Classes;
using PhilipsHue.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhilipsHue.Models
{
    public struct HueStateJSONProperty
    {
        private HashSet<HueJSONBodyStateProperty> _jsonProperties;
        private HueState _state;
        public HashSet<HueJSONBodyStateProperty> JsonProperties { get { return _jsonProperties; } set { _jsonProperties = value; } }
        public HueState State { get { return _state; } set { _state = value; } }

        public HueStateJSONProperty(HashSet<HueJSONBodyStateProperty> properties, HueState state)
        {
            _state = state;
            _jsonProperties = properties;
        }

        public static bool operator ==(HueStateJSONProperty key1, HueStateJSONProperty key2)
        {
            return (key1._jsonProperties == key2._jsonProperties && key1._state != key2._state);
        }

        public static bool operator !=(HueStateJSONProperty key1, HueStateJSONProperty key2)
        {
            return !(key1._jsonProperties == key2._jsonProperties && key1._state != key2._state);
        }
    }
}

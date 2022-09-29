using PhilipsHueAPI.Models.Enums;
using System.Data;
using System.IO;

namespace PhilipsHueAPI.Models.Classes
{
    public static class HueEndpointCollection
    {
        private static readonly Dictionary<HueEndpointKey, HueEndpoint> _collection;

        static HueEndpointCollection()
        {
            _collection = new Dictionary<HueEndpointKey, HueEndpoint>();
            FillCollection();
        }

        private static void FillCollection()
        {
            _collection.Add(HueEndpointKey.API, new HueEndpoint(HueEndpointType.OPEN, "api"));
            _collection.Add(HueEndpointKey.LIGHTS, new HueEndpoint(HueEndpointType.RESTRICTED, "lights"));
            _collection.Add(HueEndpointKey.NEWDEVELOPER, new HueEndpoint(HueEndpointType.OPEN, "newdeveloper"));
            _collection.Add(HueEndpointKey.LIGHTSSTATE, new HueEndpoint(HueEndpointType.RESTRICTED, "state"));
        }

        public static HueEndpoint GetRelatedEndpoint(HueEndpointKey key)
        {
            if (_collection.ContainsKey(key))
                return _collection[key];
            else
                return null;
        }

        public static bool Contains(HueEndpointKey key)
        {
            if (_collection.ContainsKey(key))
                return true;
            else
                return false;
        }
    }
}

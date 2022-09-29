using PhilipsHueAPI.Models.Enums;

namespace PhilipsHueAPI.Models.Classes
{
    public class HueEndpoint
    {
        private HueEndpointType _type;
        private string _path;

        public HueEndpoint(HueEndpointType type, string path)
        {
            _type = type;
            _path = path;
        }

        public HueEndpointType GetEndpointType()
        {
            return _type;
        }

        public string GetPath()
        {
            return _path;
        }
    }
}

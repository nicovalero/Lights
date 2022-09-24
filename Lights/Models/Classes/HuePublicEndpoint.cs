using PhilipsHueAPI.Models.Interfaces;

namespace PhilipsHueAPI.Models.Classes
{
    public class HuePublicEndpoint : HueEndpoint
    {
        private string _path;
        public string path { get { return _path; } set { _path = value; } }

        private HttpMethod _method;
        public HttpMethod method { get { return _method; } set { _method = value; } }

        public HuePublicEndpoint(string path, HttpMethod method)
        {
            _path = path;
            _method = method;
        }

        public string GetEndpointPath()
        {
            return path;
        }

        public HttpMethod GetHttpMethod()
        {
           return method;
        }
    }
}

using PhilipsHueAPI.Models.Interfaces;
using System.Text;

namespace PhilipsHueAPI.Models.Classes
{
    public class HueAuthorisedEndpoint: HueEndpoint
    {
        private string _firstPath;
        public string firstPath { get { return _firstPath; } set { _firstPath = value; } }

        private string _secondPath;
        public string secondPath { get { return _secondPath; } set { _secondPath = value; } }

        private HttpMethod _method;
        public HttpMethod method { get { return _method; } set { _method = value; } }

        private string _username;
        public string username { get { return _username; } set { _username = value; } }

        public HueAuthorisedEndpoint(string firstPath, string secondPath, HttpMethod method, string username)
        {
            _firstPath = firstPath;
            _secondPath = secondPath;
            _method = method;
            _username = username;
        }

        public string GetEndpointPath()
        {
            if (string.IsNullOrEmpty(username))
                return null;

            StringBuilder sb = new StringBuilder();
            sb.Append(firstPath);
            sb.Append("/");
            sb.Append(username);
            sb.Append("/");
            sb.Append(secondPath);

            return sb.ToString();
        }

        public HttpMethod GetHttpMethod()
        {
            return method;
        }
    }
}

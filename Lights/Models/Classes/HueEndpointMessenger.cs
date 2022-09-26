using System.Net;
using Microsoft.VisualBasic;
using PhilipsHueAPI.Models.Enums;
using PhilipsHueAPI.Models.Interfaces;

namespace PhilipsHueAPI.Models.Classes
{
    internal static class HueEndpointMessenger
    {
        private static Dictionary<HueEndpoint, Tuple<HueEndpointType, string>> _paths;

        static HueEndpointMessenger()
        {
            _paths = new Dictionary<HueEndpoint, Tuple<HueEndpointType, string>>();

            _paths.Add(HueEndpoint.API, new Tuple<HueEndpointType, string>(HueEndpointType.OPEN, "api"));
            _paths.Add(HueEndpoint.LIGHTS, new Tuple<HueEndpointType, string>(HueEndpointType.RESTRICTED, "lights"));
            _paths.Add(HueEndpoint.NEWDEVELOPER, new Tuple<HueEndpointType, string>(HueEndpointType.OPEN, "newdeveloper"));
        }

        internal static async Task<string> SendRequest(Uri URL, HueEndpoint endpoint, Developer developer = null, StringContent content = null)
        {
            HttpResponseMessage response = null;
            string path = GetPath(URL, endpoint, developer);

            if (!string.IsNullOrEmpty(path))
            {
                switch (GetRelatedHttpMethod(endpoint))
                {
                    case HTTPMethods.POST:
                        response = await HTTPMessenger.SendPostRequestAsync(path, content);
                        break;
                    case HTTPMethods.GET:
                        response = await HTTPMessenger.SendGetRequestAsync(path);
                        break;
                    default:
                        break;
                }
            }

            string responseContent = "";

            if(response != null)
                responseContent = await response.Content.ReadAsStringAsync();

            return responseContent;
        }

        private static HTTPMethods GetRelatedHttpMethod(HueEndpoint endpoint)
        {
            switch (endpoint)
            {
                case HueEndpoint.API:
                    return HTTPMethods.POST;
                case HueEndpoint.NEWDEVELOPER:
                    return HTTPMethods.GET;
                case HueEndpoint.LIGHTS:
                    return HTTPMethods.GET;
                default:
                    return HTTPMethods.GET;
            }
        }

        private static string GetPath(Uri URL, HueEndpoint endpoint, Developer developer)
        {
            string path = null;
            string developerID = developer.GetUsername();

            if (_paths.ContainsKey(endpoint))
            {
                switch(_paths[endpoint].Item1)
                {
                    case HueEndpointType.RESTRICTED:
                        path = URL + "api/" + developerID + "/" + _paths[endpoint].Item2;
                        break;
                    case HueEndpointType.OPEN:
                    default:
                        path = URL + _paths[endpoint].Item2;
                        break;
                }
            }

            return path;
        }
    }
}

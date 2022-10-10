using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using PhilipsHue.Models.Enums;
using PhilipsHue.Models.Interfaces;

namespace PhilipsHue.Models.Classes
{
    internal static class HueEndpointMessenger
    {
        internal static async Task<string> SendRequest(HTTPMethods method, Uri URL, List<HueEndpointKey> endpoints, Developer developer = null, StringContent content = null, string itemId = null)
        {
            HttpResponseMessage response = null;
            string path = GetPath(URL, endpoints, developer, itemId);

            if (!string.IsNullOrEmpty(path))
            {
                switch (method)
                {
                    case HTTPMethods.POST:
                        response = await HTTPMessenger.SendPostRequestAsync(path, content);
                        break;
                    case HTTPMethods.GET:
                        response = await HTTPMessenger.SendGetRequestAsync(path);
                        break;
                    case HTTPMethods.PUT:
                        response = await HTTPMessenger.SendPutRequestAsync(path, content);
                        break;
                    default:
                        break;
                }
            }
            string responseContent = "";

            if (response != null)
            {
                responseContent = await response.Content.ReadAsStringAsync();
            }

            return responseContent;
        }

        private static string GetPath(Uri URL, List<HueEndpointKey> endpoints, Developer developer, string itemId = null)
        {
            string path = null;
            string developerID = developer.GetUsername();

            if(AnyRestricted(endpoints))
                path = BuildPath(URL, endpoints, itemId, developerID);
            else
                path = BuildPath(URL, endpoints, itemId);

            return path;
        }

        private static string BuildPath(Uri URL, List<HueEndpointKey> endpointKeys, string itemId = null, string developerID = null)
        {
            string path = URL.ToString() + HueEndpointCollection.GetRelatedEndpoint(HueEndpointKey.API).GetPath();
            
            if(developerID != null)
                path += "/" + developerID;

            if(endpointKeys.Count > 0)
            {
                HueEndpoint endpoint;

                if (HueEndpointCollection.Contains(endpointKeys[0]))
                {
                    endpoint = HueEndpointCollection.GetRelatedEndpoint(endpointKeys[0]);
                    path += "/" + endpoint.GetPath().ToLower();
                }

                if (itemId != null)
                    path += "/" + itemId;

                for (int i = 1; i < endpointKeys.Count; i++)
                {
                    endpoint = HueEndpointCollection.GetRelatedEndpoint(endpointKeys[i]);
                    if (endpoint != null)
                        path += "/" + endpoint.GetPath().ToLower();
                }
            }

            return path;
        }

        private static bool AnyRestricted(List<HueEndpointKey> list)
        {
            HueEndpoint endpoint;
            foreach(HueEndpointKey endpointKey in list)
            {
                endpoint = HueEndpointCollection.GetRelatedEndpoint(endpointKey);
                if (endpoint != null)
                {
                    if (endpoint.GetEndpointType() == HueEndpointType.RESTRICTED)
                        return true;
                }
            }

            return false;
        }
    }
}

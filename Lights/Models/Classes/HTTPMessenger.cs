using PhilipsHueAPI.Models.Interfaces;
using System;

namespace PhilipsHueAPI.Models.Classes
{
    public static class HTTPMessenger
    {
        private static HttpClient _client = new HttpClient();

        private static async Task<HttpResponseMessage> SendGetRequestAsync(string path)
        {
            return await _client.GetAsync(path);
        }

        private static async Task<HttpResponseMessage> SendPostRequestAsync(string path, StringContent? data = null)
        {
            return await _client.PostAsync(path, data);
        }

        public static async Task<string> SendRequestAsync(HueEndpoint endpoint, StringContent? data = null)
        {
            HttpResponseMessage response = null;
            HttpMethod method = endpoint.GetHttpMethod();
            switch (method.Method)
            {
                case "POST":
                    response = await SendPostRequestAsync(endpoint.GetEndpointPath(), data);
                    break;
                case "GET":
                    response = await SendGetRequestAsync(endpoint.GetEndpointPath());
                    break;
                default:
                    break;
            }

            string contents = "";
            
            if(response != null)
                contents = await response.Content.ReadAsStringAsync();

            return contents;
        }
    }
}

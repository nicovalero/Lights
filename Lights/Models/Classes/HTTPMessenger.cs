using PhilipsHueAPI.Models.Interfaces;
using System;

namespace PhilipsHueAPI.Models.Classes
{
    internal static class HTTPMessenger
    {
        private static HttpClient _client = new HttpClient();

        internal static async Task<HttpResponseMessage> SendGetRequestAsync(string path)
        {
            return await _client.GetAsync(path);
        }

        internal static async Task<HttpResponseMessage> SendPostRequestAsync(string path, StringContent data = null)
        {
            return await _client.PostAsync(path, data);
        }

        internal static async Task<HttpResponseMessage> SendPutRequestAsync(string path, StringContent data = null)
        {
            return await _client.PutAsync(path, data);
        }
    }
}

using System.Net.Http;
using System.Threading.Tasks;

namespace Nanoleaf.Network
{
    internal static class HTTPMessenger
    {
        private static HttpClient _client = new HttpClient();

        internal static HttpResponseMessage SendGetRequestAsync(string path)
        {
            return _client.GetAsync(path).Result;
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

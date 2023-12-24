using System.Net.Http;
using System.Threading.Tasks;

namespace Nanoleaf.Network
{
    internal static class HTTPMessenger
    {
        private static readonly HttpClient _client;

        static HTTPMessenger()
        {
            _client = new HttpClient();
            _client.DefaultRequestHeaders.ExpectContinue = false;
        }

        internal static HttpResponseMessage SendGetRequestAsync(string path)
        {
            return _client.GetAsync(path).Result;
        }

        internal static async Task<HttpResponseMessage> SendPostRequestAsync(string path, StringContent data = null)
        {
            return await _client.PostAsync(path, data);
        }

        internal static Task SendPutRequestAsync(string path, StringContent data = null)
        {
            return _client.PutAsync(path, data);
        }
    }
}

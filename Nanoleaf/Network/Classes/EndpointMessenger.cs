using Nanoleaf.Network.Enums;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace Nanoleaf.Network.Classes
{
    internal static class EndpointMessenger
    {
        private const string APIPATH = "/api/v1";
        private const string NEWDEVELOPERPATH = APIPATH + "/new";
        private const int PORT = 16021;

        internal static async Task<string> SendNewDeveloperRequest(Uri URL)
        {
            HttpResponseMessage response = null;
            var builder = new UriBuilder(URL);
            builder.Path = NEWDEVELOPERPATH;
            builder.Port = PORT;

            var path = builder.Uri.ToString();
            response = await HTTPMessenger.SendPostRequestAsync(path);
            string responseContent = "";

            if (response != null)
            {
                responseContent = await response.Content.ReadAsStringAsync();
            }

            return responseContent;
        }

        internal static async Task<string> GetAllLightControllerInfoRequest(Uri URL, DeveloperAuthToken token)
        {
            HttpResponseMessage response = null;
            var builder = new UriBuilder(URL);
            builder.Path = string.Format("{0}/{1}/", APIPATH, token.GetToken());
            builder.Port = PORT;

            var path = builder.Uri.ToString();
            response = HTTPMessenger.SendGetRequestAsync(path);
            string responseContent = "";

            if (response != null)
            {
                responseContent = await response.Content.ReadAsStringAsync();
            }

            return responseContent;
        }
    }
}

﻿using Nanoleaf.Devices.ShapesPanelLayoutClasses;
using Nanoleaf.Network.Classes.Requests.ShapesRequests;
using Nanoleaf.Network.Classes.Responses;
using Nanoleaf.Network.Enums;
using Nanoleaf.Network.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Nanoleaf.Network.Classes
{
    internal static class EndpointMessenger
    {
        private const string APIPATH = "/api/v1";
        private const string NEWDEVELOPERPATH = APIPATH + "/new";
        private const string PANELLAYOUTPATH = "/panelLayout/layout";
        private const string STATEPATH = "state";
        private const string SATURATIONPATH = STATEPATH + "/sat";
        private const string EFFECTSPATH = "effects";
        private const int PORT = 16021;

        internal static async Task<DeveloperAuthTokenResponse> SendNewDeveloperRequest(Uri URL)
        {
            HttpResponseMessage response = null;
            var builder = new UriBuilder(URL);
            builder.Path = NEWDEVELOPERPATH;
            builder.Port = PORT;

            var path = builder.Uri.ToString();
            response = HTTPMessenger.SendPostRequestAsync(path);
            DeveloperAuthTokenResponse devAuthTokenResponse = null;

            if (response != null)
            {
                var responseContent = await response.Content.ReadAsStringAsync();
                devAuthTokenResponse = JsonConvert.DeserializeObject<DeveloperAuthTokenResponse>(responseContent);
            }

            return devAuthTokenResponse;
        }

        internal static async Task<ShapesLayout> SendLayoutRequest(Uri URL, DeveloperAuthToken token)
        {
            HttpResponseMessage response = null;
            var builder = new UriBuilder(URL);
            builder.Path = string.Format("{0}/{1}{2}", APIPATH, token.GetToken(), PANELLAYOUTPATH);
            builder.Port = PORT;

            var path = builder.Uri.ToString();
            response = HTTPMessenger.SendGetRequestAsync(path);
            ShapesLayout layoutResponse = null;

            if (response != null)
            {
                var responseContent = await response.Content.ReadAsStringAsync();
                layoutResponse = JsonConvert.DeserializeObject<ShapesLayout>(responseContent);
            }

            return layoutResponse;
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

        internal static void UpdateStateRequest(Uri URL, DeveloperAuthToken token, IUpdateStateRequest request)
        {
            var builder = new UriBuilder(URL);
            builder.Path = string.Format("{0}/{1}/{2}/", APIPATH, token.GetToken(), STATEPATH);
            builder.Port = PORT;

            var json = request.GetSerializedJson();
            StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

            var path = builder.Uri.ToString();
            HTTPMessenger.SendPutRequestAsync(path, content);
        }

        internal static void UpdateSaturationRequest(Uri URL, DeveloperAuthToken token, IUpdateSaturationRequest request)
        {
            var builder = new UriBuilder(URL);
            builder.Path = string.Format("{0}/{1}/{2}", APIPATH, token.GetToken(), SATURATIONPATH);
            builder.Port = PORT;

            var json = request.GetSerializedJson();
            StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

            var path = builder.Uri.ToString();
            HTTPMessenger.SendPutRequestAsync(path, content);
        }

        internal static void UpdateEffectsRequest(Uri URL, DeveloperAuthToken token, IUpdateEffectsRequest request)
        {
            var builder = new UriBuilder(URL);
            builder.Path = string.Format("{0}/{1}/{2}/", APIPATH, token.GetToken(), EFFECTSPATH);
            builder.Port = PORT;

            var json = request.GetSerializedJson();
            StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

            var path = builder.Uri.ToString();
            HTTPMessenger.SendPutRequestAsync(path, content);
        }
    }
}

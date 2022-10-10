﻿using PhilipsHue.Models.Interfaces;
using System;
using Newtonsoft.Json;
using PhilipsHue.Models.Enums;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Net;

namespace PhilipsHue.Models.Classes
{
    public class HueBridgeV2 : Bridge
    {
        private Uri _URL;
        private Dictionary<int, Scene> _scenes;
        private Dictionary<string, HueColorLight> _lights;
        private Dictionary<int, Group> _groups;
        private HueDeveloper _developer;

        public Uri URL { get { return _URL; } set { _URL = value; } }
        public HueDeveloper developer { get { return _developer; } set { _developer = value; } }
        public Dictionary<string, HueColorLight> lights { get { return _lights; } set { _lights = value; } }

        public HueBridgeV2(Uri uri)
        {
            _URL = uri;
            _scenes = new Dictionary<int, Scene>();
            _lights = new Dictionary<string, HueColorLight>();
            _groups = new Dictionary<int, Group>();
            _developer = new HueDeveloper("qFtbsJJ6H2SvZthKQWqECEctGQozVGQZRepoCnZw");

            ServicePointManager.FindServicePoint(uri).ConnectionLimit = 20;
        }

        public void AddGroup(int key, Group group)
        {
            _groups.Add(key, group);
        }

        public void AddLight(string key, HueLight light)
        {
            _lights.Add(key, (HueColorLight)light);
        }

        public void AddScene(int key, Scene scene)
        {
            _scenes.Add(key, scene);
        }

        public bool Connect()
        {
            bool connected = true;
            string username = developer.GetUsername();

            if (string.IsNullOrEmpty(username))
            {
                if (!SetNewDeveloper())
                    connected = false;
            }

            if (connected)
            {
                DownloadLights().Wait();
                //DownloadGroups();
                //DownloadScenes();
            }

            return connected;
        }

        public bool SetNewDeveloper()
        {
            developer.SetNewDeveloperAsync(URL, HueEndpointKey.NEWDEVELOPER).Wait();

            if (!string.IsNullOrEmpty(developer.GetUsername()))
                return true;
            else
                return false;
        }

        public async Task DownloadLights()
        {
            List<HueEndpointKey> endpoints = new List<HueEndpointKey>();
            endpoints.Add(HueEndpointKey.LIGHTS);

            var contents = await HueEndpointMessenger.SendRequest(HTTPMethods.GET, URL, endpoints, developer);

            ParseLights(contents);
        }

        public HueLight GetLight(string id)
        {
            if (lights.ContainsKey(id))
                return lights[id];
            else
                return null;
        }

        public void ParseLights(string content)
        {
            try
            {
                Dictionary<string, HueColorLight> hueDevResponse = JsonConvert.DeserializeObject<Dictionary<string, HueColorLight>>(content);
                if(hueDevResponse != null)
                {
                    lights = hueDevResponse;
                }
            }
            catch(Exception e)
            {

            }
        }

        public async Task ChangeLightState(string id, HueState state, List<HueJSONBodyStateProperty> properties)
        {
            HueLight light = GetLight(id);
            light.ChangeStateProperties(state, properties);

            var data = state.GenerateJSONBody(properties);
            string d = data.ToString();
            List<HueEndpointKey> endpoints = new List<HueEndpointKey>();
            endpoints.Add(HueEndpointKey.LIGHTS);
            endpoints.Add(HueEndpointKey.LIGHTSSTATE);

            await HueEndpointMessenger.SendRequest(HTTPMethods.PUT, URL, endpoints, developer, data, id);
        }
    }
}
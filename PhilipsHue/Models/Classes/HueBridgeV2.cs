using PhilipsHue.Models.Interfaces;
using System;
using Newtonsoft.Json;
using PhilipsHue.Models.Enums;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Net;
using System.Linq;

namespace PhilipsHue.Models.Classes
{
    public class HueBridgeV2 : Bridge
    {
        private Uri _URL;
        private Dictionary<int, Scene> _scenes;
        private Dictionary<string, HueLight> _lights;
        private Dictionary<int, Group> _groups;
        private HueDeveloper _developer;
        public Dictionary<string, string> _uniqueIdJsonPairs;

        internal Dictionary<int, Scene> Scenes { get { return _scenes; } private set { _scenes = value; } }
        internal Dictionary<string, HueLight> Lights { get { return _lights; } private set { _lights = value; } }
        internal Dictionary<int,Group> Groups { get { return _groups; } private set { _groups = value; } }

        public Uri URL { get { return _URL; } set { _URL = value; } }
        public HueDeveloper developer { get { return _developer; } set { _developer = value; } }
        public Dictionary<string, HueLight> lights { get { return _lights; } set { _lights = value; } }
        public Dictionary<string, string> uniqueIdJsonPairs { get { return _uniqueIdJsonPairs; } set { _uniqueIdJsonPairs = value; } }

        public HueBridgeV2(Uri uri)
        {
            _URL = uri;
            _scenes = new Dictionary<int, Scene>();
            _lights = new Dictionary<string, HueLight>();
            _groups = new Dictionary<int, Group>();
            _uniqueIdJsonPairs = new Dictionary<string, string>();
            _developer = new HueDeveloper("qFtbsJJ6H2SvZthKQWqECEctGQozVGQZRepoCnZw");

            if(uri != null)
                ServicePointManager.FindServicePoint(uri).ConnectionLimit = 20;
        }

        public void AddGroup(int key, Group group)
        {
            if(group != null)
                _groups.Add(key, group);
        }

        public void AddLight(string key, HueLight light)
        {
            _lights.Add(key, light);
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
                DownloadLights();
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

        public void DownloadLights()
        {
            List<HueEndpointKey> endpoints = new List<HueEndpointKey>();
            endpoints.Add(HueEndpointKey.LIGHTS);

            var contents = HueEndpointMessenger.SendRequest(HTTPMethods.GET, URL, endpoints, developer).Result;

            ParseLights(contents);
        }

        public HueLight GetLight(string uniqueid)
        {
            if (lights.ContainsKey(uniqueid))
                return lights[uniqueid];
            else
                return null;
        }

        public List<HueLight> GetAllLights()
        {
            return lights.Values.ToList();
        }

        public void ParseLights(string content)
        {
            try
            {
                Dictionary<string, HueColorLight> hueDevResponse = JsonConvert.DeserializeObject<Dictionary<string, HueColorLight>>(content);
                if(hueDevResponse != null)
                {
                    foreach(KeyValuePair<string, HueColorLight> kvp in hueDevResponse)
                    {
                        lights.Add(kvp.Value.GetUniqueId(), kvp.Value);
                        uniqueIdJsonPairs.Add(kvp.Value.GetUniqueId(), kvp.Key);
                    }
                }
            }
            catch(Exception e)
            {

            }
        }

        public async Task ChangeLightState(string uniqueid, HueState state, List<HueJSONBodyStateProperty> properties)
        {
            if (lights.ContainsKey(uniqueid) && uniqueIdJsonPairs.ContainsKey(uniqueid))
            {
                HueLight light = GetLight(uniqueid);
                light.ChangeStateProperties(state, properties);

                var data = state.GenerateJSONBody(properties);
                string d = data.ToString();
                List<HueEndpointKey> endpoints = new List<HueEndpointKey>();
                endpoints.Add(HueEndpointKey.LIGHTS);
                endpoints.Add(HueEndpointKey.LIGHTSSTATE);

                await HueEndpointMessenger.SendRequest(HTTPMethods.PUT, URL, endpoints, developer, data, uniqueIdJsonPairs[uniqueid]);
            }
        }
    }
}

using PhilipsHueAPI.Models.Interfaces;
using System.Net.Http;
using System;
using System.Reflection.Metadata.Ecma335;
using System.Net;
using System.Text;
using Newtonsoft.Json;
using PhilipsHueAPI.Models.Enums;

namespace PhilipsHueAPI.Models.Classes
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
            developer.SetNewDeveloperAsync(URL, HueEndpoint.NEWDEVELOPER).Wait();

            if (!string.IsNullOrEmpty(developer.GetUsername()))
                return true;
            else
                return false;
        }

        public async Task DownloadLights()
        {
            var contents = await HueEndpointMessenger.SendRequest(URL, HueEndpoint.LIGHTS, developer);

            ParseLights(contents);
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
    }
}

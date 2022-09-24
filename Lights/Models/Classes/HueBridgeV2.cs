using PhilipsHueAPI.Models.Interfaces;
using System.Net.Http;
using System;
using System.Reflection.Metadata.Ecma335;
using System.Net;
using System.Text;
using Newtonsoft.Json;

namespace PhilipsHueAPI.Models.Classes
{
    public class HueBridgeV2 : Bridge
    {
        private Uri _URL;
        private Dictionary<int, Scene> _scenes;
        private Dictionary<int, Light> _lights;
        private Dictionary<int, Group> _groups;
        private HueDeveloper _developer;
        public HueDeveloper developer { get { return _developer; } set { _developer = value; } }

        public HueBridgeV2(Uri uri)
        {
            _URL = uri;
            _scenes = new Dictionary<int, Scene>();
            _lights = new Dictionary<int, Light>();
            _groups = new Dictionary<int, Group>();
            _developer = new HueDeveloper("qFtbsJJ6H2SvZthKQWqECEctGQozVGQZRepoCnZw");
        }

        public void AddGroup(int key, Group group)
        {
            _groups.Add(key, group);
        }

        public void AddLight(int key, Light light)
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
            HuePublicEndpoint endpoint = new HuePublicEndpoint(_URL + "api", HttpMethod.Post);
            developer.SetNewDeveloperAsync(endpoint).Wait();

            if (!string.IsNullOrEmpty(developer.GetUsername()))
                return true;
            else
                return false;
        }

        public async Task DownloadLights()
        {
            HueAuthorisedEndpoint endpoint = new HueAuthorisedEndpoint(_URL + "api", "lights", HttpMethod.Get, developer.GetUsername());

            var json = JsonConvert.SerializeObject(this);
            var data = new StringContent(json, Encoding.UTF8, "application/json");

            var contents = await HTTPMessenger.SendRequestAsync(endpoint);
        }
    }
}

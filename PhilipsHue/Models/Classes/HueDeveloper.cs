using Microsoft.VisualBasic;
using Newtonsoft.Json;
using PhilipsHue.Models.Enums;
using PhilipsHue.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace PhilipsHue.Models.Classes
{
    public class HueDeveloper: Developer
    {
        private string _devicetype;
        public string devicetype { get { return _devicetype; } set { _devicetype = value; } }

        private string _username;

        public HueDeveloper()
        {
            _devicetype = "";
            _username = "";
        }

        public HueDeveloper(string username)
        {
            _devicetype = "";
            _username = username;
        }

        public HueDeveloper(string devicetype, string username)
        {
            _devicetype = devicetype;
            _username = username;
        }

        public string GetDeviceType()
        {
            return this.devicetype;
        }

        public string GetUsername()
        {
            return _username;
        }

        public async Task<bool> SetNewDeveloperAsync(Uri URL, HueEndpointKey endpoint)
        {
            List<HueEndpointKey> endpoints = new List<HueEndpointKey>();
            endpoints.Add(HueEndpointKey.NEWDEVELOPER);

            var json = JsonConvert.SerializeObject(this);
            var data = new StringContent(json, Encoding.UTF8, "application/json");

            var contents = await HueEndpointMessenger.SendRequest(HTTPMethods.GET, URL, endpoints, content: data);
            if (contents != null)
            {
                ParseResponseContent(contents);

                if (!string.IsNullOrEmpty(_username))
                    return true;
            }

            return false;
        }

        private void ParseResponseContent(string content)
        {
            List<HueDeveloperResponse> hueDevResponse = JsonConvert.DeserializeObject<List<HueDeveloperResponse>>(content);
            if (hueDevResponse != null)
            {
                if (hueDevResponse[0].HasSuccess())
                {
                    _username = hueDevResponse[0].success.username;
                }
            }
        }
    }
}

using Microsoft.VisualBasic;
using Newtonsoft.Json;
using PhilipsHueAPI.Models.Interfaces;
using System.Text;

namespace PhilipsHueAPI.Models.Classes
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

        public string GetName()
        {
            return this.devicetype;
        }

        public async Task<bool> SetNewDeveloperAsync(HueEndpoint endpoint)
        {
            var json = JsonConvert.SerializeObject(this);
            var data = new StringContent(json, Encoding.UTF8, "application/json");

            var contents = await HTTPMessenger.SendRequestAsync(endpoint, data);
            if (contents != null)
            {
                ParseResponseContent(contents);

                if (!string.IsNullOrEmpty(_username))
                    return true;
            }

            return false;
        }

        public string GetUsername()
        {
            return _username;
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

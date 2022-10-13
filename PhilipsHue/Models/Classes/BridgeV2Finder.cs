using Newtonsoft.Json;
using PhilipsHue.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace PhilipsHue.Models.Classes
{
    internal class BridgeV2Finder : BridgeFinder
    {
        public bool Exist(Uri uri)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Bridge>> FindAll()
        {
            List<Bridge> bridges = new List<Bridge>();
            string path = "https://discovery.meethue.com";
            HttpResponseMessage response = await HTTPMessenger.SendGetRequestAsync(path);

            string responseContent = "";

            if (response != null)
            {
                responseContent = await response.Content.ReadAsStringAsync();
                List<HueBridgeV2Response> list = ParseResponseContent(responseContent);
                ConvertToBridgeV2(list);
            }

            return bridges;
        }

        private List<HueBridgeV2Response> ParseResponseContent(string content)
        {
            return JsonConvert.DeserializeObject<List<HueBridgeV2Response>>(content);
        }

        private List<HueBridgeV2> ConvertToBridgeV2(List<HueBridgeV2Response> content)
        {
            List<HueBridgeV2> bridges = new List<HueBridgeV2>();
            HueBridgeV2 bridge;
            Uri uri;

            foreach (HueBridgeV2Response response in content)
            {
                if(!response.internalipaddress.Contains("http://"))
                    uri = new Uri("http://" + response.internalipaddress);
                else
                    uri = new Uri(response.internalipaddress);
                bridge = new HueBridgeV2(uri);
                bridges.Add(bridge);
            }

            return bridges;
        }
    }
}

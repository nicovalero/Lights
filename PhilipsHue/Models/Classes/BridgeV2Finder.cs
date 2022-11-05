﻿using Newtonsoft.Json;
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
        private string _path;
        internal BridgeV2Finder(string path)
        {
            _path = path;
        }
        public bool Exist(Uri uri)
        {
            throw new NotImplementedException();
        }

        public List<Bridge> FindAll()
        {
            List<Bridge> bridges = new List<Bridge>();
            if (_path != null)
            {
                HttpResponseMessage response = HTTPMessenger.SendGetRequestAsync(_path);

                if (response != null)
                {
                    string responseContent = response.Content.ReadAsStringAsync().Result;
                    List<HueBridgeV2Response> list = ParseResponseContent(responseContent);
                    bridges = ConvertToBridgeV2(list);
                }
            }

            return bridges;
        }

        //Need to create this function since calling to discovery.meethue.com
        //ended up in a 429 Too Many Requests ban XD.
        //Need to sort out that by not calling this bloody URL.
        public List<Bridge> FindAllManual()
        {
            List<Bridge> bridges = new List<Bridge>();
            HueBridgeV2 bridgeV2 = new HueBridgeV2(new Uri("http://192.168.1.213"));
            bridges.Add(bridgeV2);

            return bridges;
        }

        private List<HueBridgeV2Response> ParseResponseContent(string content)
        {
            try
            {
                var result = JsonConvert.DeserializeObject<List<HueBridgeV2Response>>(content);
                return result;
            }
            catch
            {
                return new List<HueBridgeV2Response>();
            }
        }

        private List<Bridge> ConvertToBridgeV2(List<HueBridgeV2Response> content)
        {
            List<Bridge> bridges = new List<Bridge>();
            Bridge bridge;
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

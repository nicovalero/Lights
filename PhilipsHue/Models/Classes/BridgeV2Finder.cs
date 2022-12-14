using Makaretu.Dns;
using Newtonsoft.Json;
using PhilipsHue.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PhilipsHue.Models.Classes
{
    internal class BridgeV2Finder : BridgeFinder
    {
        private mDNSClient _mDNSClient;
        private const string MEETHUEPATH = "https://discovery.meethue.com";
        private const string HUEQUERY = "_hue._tcp.local";
        private const string BRIDGEMESSAGEKEY = "._hue._tcp.local";
        private EventHandler<Bridge> _ipHandler;

        internal BridgeV2Finder(EventHandler<Bridge> ipHandler)
        {
            _mDNSClient = new mDNSClient(mDNSAnswerReceived);
            _ipHandler = ipHandler;
        }

        public bool Exist(Uri uri)
        {
            throw new NotImplementedException();
        }

        public void FindAllmDNSMulticast()
        {
            //Task.Factory.StartNew(() => _mDNSClient.SendQuery(HUEQUERY));
            _mDNSClient.SendQuery(HUEQUERY);
        }

        public List<Bridge> FindAllOnline()
        {
            return GetBridgesFromPath(MEETHUEPATH);
        }

        //Need to create this function since calling to discovery.meethue.com
        //ended up in a 429 Too Many Requests ban XD.
        //Need to sort out that by not calling this bloody URL.
        public Bridge FindManual(Uri uri)
        {
            return new HueBridgeV2(uri);
        }

        public List<Bridge> GetBridgesFromPath(string path)
        {
            List<Bridge> bridges = new List<Bridge>();
            HttpResponseMessage response = HTTPMessenger.SendGetRequestAsync(path);

            string responseContent = "";

            if (response != null)
            {
                responseContent = response.Content.ReadAsStringAsync().Result;
                List<HueBridgeV2Response> list = ParseResponseContent(responseContent);
                bridges = ConvertToBridgeV2(list);
            }

            return bridges;
        }

        private List<HueBridgeV2Response> ParseResponseContent(string content)
        {
            return JsonConvert.DeserializeObject<List<HueBridgeV2Response>>(content);
        }

        private List<Bridge> ConvertToBridgeV2(List<HueBridgeV2Response> content)
        {
            List<Bridge> bridges = new List<Bridge>();
            Bridge bridge;
            Uri uri;

            foreach (HueBridgeV2Response response in content)
            {
                if (!response.internalipaddress.Contains("http://"))
                    uri = new Uri("http://" + response.internalipaddress);
                else
                    uri = new Uri(response.internalipaddress);
                bridge = new HueBridgeV2(uri);
                bridges.Add(bridge);
            }

            return bridges;
        }

        private void mDNSAnswerReceived(object sender, MessageEventArgs e)
        {
            string message = e.Message.ToString();
            if (ValidAnswer(message) && ValidEndPointAddressFamily(e.RemoteEndPoint))
            {
                if (_ipHandler != null)
                {

                    string path = e.RemoteEndPoint.Address.ToString();
                    if (!path.Contains("http://"))
                        path = "http://" + path;
                    Bridge bridge = new HueBridgeV2(new Uri(path));
                    _ipHandler(this, bridge);
                }
            }
        }

        private bool ValidAnswer(string s)
        {
            if (s.Contains(BRIDGEMESSAGEKEY))
                return true;
            else
                return false;
        }

        private bool ValidEndPointAddressFamily(IPEndPoint endpoint)
        {
            if (endpoint.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                return true;
            else
                return false;
        }
    }
}

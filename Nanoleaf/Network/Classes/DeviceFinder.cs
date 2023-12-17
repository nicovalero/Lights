using Nanoleaf.Network.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Makaretu.Dns;
using Newtonsoft.Json;
using Nanoleaf.Devices.Interfaces;
using Nanoleaf.Devices.Classes;

namespace Nanoleaf.Network.Classes
{
    internal class DeviceFinder: IDeviceFinder
    {
        private mDNSClient _mDNSClient;
        private const string MEETHUEPATH = "https://discovery.meethue.com";
        private const string NANOLEAFQUERY = "_hap._tcp.local";
        private const string DEVICEMESSAGEKEY = "_hap._tcp.local";
        private EventHandler<INanoleafShapes> _ipHandler;

        internal DeviceFinder(EventHandler<INanoleafShapes> ipHandler)
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
            _mDNSClient.SendQuery(NANOLEAFQUERY);
        }

        public List<INanoleafShapes> FindAllOnline()
        {
            return GetdevicesFromPath(MEETHUEPATH);
        }

        //Need to create this function since calling to discovery.meethue.com
        //ended up in a 429 Too Many Requests ban XD.
        //Need to sort out that by not calling this bloody URL.
        public INanoleafShapes FindManual(Uri uri)
        {
            return new Shapes(uri);
        }

        public List<INanoleafShapes> GetdevicesFromPath(string path)
        {
            List<INanoleafShapes> devices = new List<INanoleafShapes>();
            HttpResponseMessage response = HTTPMessenger.SendGetRequestAsync(path);

            string responseContent = "";

            if (response != null)
            {
                responseContent = response.Content.ReadAsStringAsync().Result;
                List<NanoleafDeviceResponse> list = ParseResponseContent(responseContent);
                devices = ConvertTodeviceV2(list);
            }

            return devices;
        }

        private List<NanoleafDeviceResponse> ParseResponseContent(string content)
        {
            return JsonConvert.DeserializeObject<List<NanoleafDeviceResponse>>(content);
        }

        private List<INanoleafShapes> ConvertTodeviceV2(List<NanoleafDeviceResponse> content)
        {
            List<INanoleafShapes> devices = new List<INanoleafShapes>();
            INanoleafShapes device;
            Uri uri;

            foreach (NanoleafDeviceResponse response in content)
            {
                if (!response.internalipaddress.Contains("http://"))
                    uri = new Uri("http://" + response.internalipaddress);
                else
                    uri = new Uri(response.internalipaddress);
                device = new Shapes(uri);
                devices.Add(device);
            }

            return devices;
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
                    INanoleafShapes device = new Shapes(new Uri(path));
                    _ipHandler(this, device);
                }
            }
        }

        private bool ValidAnswer(string s)
        {
            if (s.Contains(DEVICEMESSAGEKEY))
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

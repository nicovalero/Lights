using Nanoleaf.Network.Interfaces;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net;
using Makaretu.Dns;
using Newtonsoft.Json;
using Nanoleaf.Devices.Interfaces;
using Nanoleaf.Devices.Classes;

namespace Nanoleaf.Network.Classes
{
    internal class DeviceFinder: IDeviceFinder
    {
        private mDNSClient _mDNSClient;
        private const string NANOLEAFQUERY = "_hap._tcp.local";
        private const string DEVICEMESSAGEKEY = "_hap._tcp.local";
        private EventHandler<Uri> _ipHandler;

        internal DeviceFinder(EventHandler<Uri> ipHandler)
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
                    _ipHandler(this, new Uri(path));
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

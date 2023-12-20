﻿using Nanoleaf.Network.Interfaces;
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

        //Need to create this function since calling to discovery.meethue.com
        //ended up in a 429 Too Many Requests ban XD.
        //Need to sort out that by not calling this bloody URL.
        public INanoleafShapes FindManual(Uri uri)
        {
            return new Shapes(uri);
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using Makaretu.Dns;
using System.Runtime.CompilerServices;

namespace PhilipsHue.Models.Classes
{
    internal class mDNSClient
    {
        private MulticastService _multicastService;
        internal MulticastService MulticastService { get { return _multicastService; } set { _multicastService = value; } }

        internal mDNSClient(EventHandler<MessageEventArgs> answerReceivedHandler)
        {
            _multicastService = new MulticastService();
            _multicastService.AnswerReceived += answerReceivedHandler;
        }

        internal void SendQuery(string query)
        {
            _multicastService.NetworkInterfaceDiscovered += (s, e) => _multicastService.SendQuery(query);
            StartDiscovery();
            Thread.Sleep(1000);
            StopDiscovery();
        }

        internal void StartDiscovery()
        {
            MulticastService.Start();
        }

        internal void StopDiscovery()
        {
            MulticastService.Stop();
        }
    }
}

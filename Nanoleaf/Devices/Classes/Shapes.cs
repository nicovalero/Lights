using Nanoleaf.Devices.Interfaces;
using Nanoleaf.Network.Classes;
using System;
using System.Security.Policy;

namespace Nanoleaf.Devices.Classes
{
    internal class Shapes: INanoleafShapes
    {
        public Uri URL { get; set; }
        private DeveloperAuthToken developerAuthToken;

        public Shapes(Uri uRL)
        {
            URL = uRL;
        }

        public void Connect()
        {

        }

        public bool HasAuthToken()
        {
            return developerAuthToken != null;
        }

        public Uri GetURL()
        {
            return URL;
        }

        public void SetDeveloperAuthToken(DeveloperAuthToken authToken)
        {
            developerAuthToken = authToken;
        }

        public DeveloperAuthToken GetDeveloperAuthToken()
        {
            return developerAuthToken;
        }
    }
}

using Nanoleaf.Devices.Interfaces;
using Nanoleaf.Network.Classes;
using System;
using System.Collections.Generic;
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

        public override bool Equals(object obj)
        {
            var instance = obj as Shapes;
            return instance.URL == this.URL && instance.developerAuthToken == this.developerAuthToken;
        }

        public override int GetHashCode()
        {
            int hashCode = -1842355318;
            hashCode = hashCode * -1521134295 + EqualityComparer<Uri>.Default.GetHashCode(URL);
            hashCode = hashCode * -1521134295 + EqualityComparer<DeveloperAuthToken>.Default.GetHashCode(developerAuthToken);
            return hashCode;
        }
    }
}

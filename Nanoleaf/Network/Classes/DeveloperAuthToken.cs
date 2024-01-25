using Nanoleaf.Network.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nanoleaf.Network.Classes
{
    public class DeveloperAuthToken : IDeveloperAuthToken
    {
        private string authToken;

        public DeveloperAuthToken(string authToken)
        {
            this.authToken = authToken;
        }

        public string GetToken()
        {
            return authToken;
        }

        public void SetToken(string token)
        {
            authToken = token;
        }
    }
}

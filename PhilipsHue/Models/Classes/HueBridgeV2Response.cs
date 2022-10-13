using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace PhilipsHue.Models.Classes
{
    internal class HueBridgeV2Response
    {
        private string _id;
        private string _internalipaddress;
        private string _port;

        public string id { get { return _id; } set { _id = value; } }
        public string internalipaddress { get { return _internalipaddress; } set { _internalipaddress = value; } }
        public string port { get { return _port; } set { _port = value; } }
    }
}

using PhilipsHue.Models.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhilipsHue.Models.Interfaces
{
    internal interface BridgeFinder
    {
        bool Exist(Uri uri);

        void FindAllmDNSMulticast();
        List<Bridge> FindAllOnline();
        Bridge FindManual(Uri uri);
    }
}

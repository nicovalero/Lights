using Nanoleaf.Network.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nanoleaf.Devices.Interfaces
{
    internal interface INanoleafShapes
    {
        void Connect();
        bool HasAuthToken();
        Uri GetURL();
        void SetDeveloperAuthToken(DeveloperAuthToken authToken);
        DeveloperAuthToken GetDeveloperAuthToken();
    }
}

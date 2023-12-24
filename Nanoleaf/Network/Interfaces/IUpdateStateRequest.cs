using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nanoleaf.Network.Interfaces
{
    internal interface IUpdateStateRequest
    {
        string GetSerializedJson();
    }
}

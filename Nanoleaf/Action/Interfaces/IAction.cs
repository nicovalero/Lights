using Nanoleaf.Network.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading.Tasks;

namespace Nanoleaf.Action.Interfaces
{
    internal interface IAction
    {
        IResponse Perform();
    }
}

using Nanoleaf.Network.Classes.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nanoleaf.Devices.Interfaces
{
    internal interface IShapesPanelFactory
    {
        HashSet<IShapesPanel> GetPanelSet(AllLightControllerInfoResponse response);
    }
}

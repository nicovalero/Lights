using Nanoleaf.Action.Actions;
using Nanoleaf.Devices.Interfaces;
using Nanoleaf.Network.Classes;
using Nanoleaf.Network.Classes.Responses;
using Nanoleaf.Network.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nanoleaf.Action.Classes
{
    internal class ActionController
    {
        public AllLightControllerInfoResponse GetShapesPanelList(INanoleafShapes shapes)
        {
            var action = new GetAllLightControllerInfoAction(shapes);
            var result = action.Perform();

            return result;
        }
    }
}

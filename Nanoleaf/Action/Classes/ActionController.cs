using Nanoleaf.Action.Actions;
using Nanoleaf.Action.Interfaces;
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
    public class ActionController
    {
        internal void PerformSimpleAction(Dictionary<IShapesPanel, INanoleafShapes> shapesSet, IAction action)
        {
            action.Perform();
        }

        internal void PerformEffectAction(Dictionary<IShapesPanel,INanoleafShapes> shapesSet, INanoleafEffectAction action)
        {
            action.Perform();
        }
    }
}

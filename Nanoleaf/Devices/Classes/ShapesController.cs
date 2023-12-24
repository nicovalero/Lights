using Nanoleaf.Action.Actions.ShapesActions;
using Nanoleaf.Action.Classes;
using Nanoleaf.Devices.Interfaces;
using Nanoleaf.Network;
using Nanoleaf.Network.Classes;
using Nanoleaf.Network.Classes.Responses;
using Nanoleaf.Network.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Nanoleaf.Devices.Classes
{
    internal class ShapesController
    {
        public INanoleafShapes LinkedShapes { get; private set; }
        private ActionController actionController;

        public ShapesController(ActionController actionController, INanoleafShapes shapes)
        {
            LinkedShapes = shapes;
            this.actionController = actionController;
        }

        public void UpdateBrightness(UpdateBrightnessActionValues values)
        {
            var action = new ShapesUpdateBrightnessAction(LinkedShapes, values);
            action.Perform();
        }

        public void UpdateEffects(ShapesUpdateEffectsActionValues values)
        {
            var action = new ShapesUpdateEffectsAction(LinkedShapes, values);
            action.Perform();
        }
    }
}

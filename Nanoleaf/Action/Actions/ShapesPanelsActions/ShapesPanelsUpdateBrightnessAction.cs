using Nanoleaf.Action.Interfaces;
using Nanoleaf.Devices.Classes;
using Nanoleaf.Network.Classes.Responses;
using Nanoleaf.Network.Classes;
using Nanoleaf.Network.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nanoleaf.Devices.Interfaces;
using Nanoleaf.Network.Classes.Requests.ShapesRequests;
using Nanoleaf.Action.Actions.ShapesActions;

namespace Nanoleaf.Action.Actions.ShapesPanelsActions
{
    internal class ShapesPanelsUpdateBrightnessAction: IAction
    {
        private INanoleafShapes shapes;
        private UpdateBrightnessActionValues values;

        internal ShapesPanelsUpdateBrightnessAction(INanoleafShapes shapes, UpdateBrightnessActionValues values)
        {
            this.shapes = shapes;
            this.values = values;
        }

        public bool Perform()
        {
            var request = new UpdateBrightnessRequest(values.brightness, values.duration);
            EndpointMessenger.UpdateStateRequest(shapes.URL, shapes.DeveloperAuthToken, request);

            return true;
        }
    }
}

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
    internal class ShapesPanelsUpdateSaturationAction
    {
        private INanoleafShapes shapes;
        private ShapesUpdateSaturationActionValues values;

        internal ShapesPanelsUpdateSaturationAction(INanoleafShapes shapes, ShapesUpdateSaturationActionValues values)
        {
            this.shapes = shapes;
            this.values = values;
        }

        public void Perform()
        {
            var request = new UpdateSaturationRequest(values);
            EndpointMessenger.UpdateSaturationRequest(shapes.URL, shapes.DeveloperAuthToken, request);
        }
    }
}

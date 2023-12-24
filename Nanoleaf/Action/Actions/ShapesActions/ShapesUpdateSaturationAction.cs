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

namespace Nanoleaf.Action.Actions.ShapesActions
{
    internal struct ShapesUpdateSaturationActionValues
    {
        public int value;
        public ShapesUpdateSaturationActionValues(int value)
        {
            this.value = value;
        }
    }
    internal class ShapesUpdateSaturationAction
    {
        private INanoleafShapes shapes;
        private ShapesUpdateSaturationActionValues values;

        internal ShapesUpdateSaturationAction(INanoleafShapes shapes, ShapesUpdateSaturationActionValues values)
        {
            this.shapes = shapes;
            this.values = values;
        }

        public void Perform()
        {
            var request = new UpdateSaturationRequest(values);
            EndpointMessenger.UpdateSaturationRequest(shapes.GetURL(), shapes.GetDeveloperAuthToken(), request);
        }
    }
}

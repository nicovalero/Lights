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
    internal struct ShapesUpdateHueActionValues
    {
        public int value, max, min;
        public ShapesUpdateHueActionValues(int value, int max, int min)
        {
            this.value = value;
            this.max = max;
            this.min = min;
        }
    }
    internal class ShapesUpdateHueAction
    {
        private INanoleafShapes shapes;
        private ShapesUpdateHueActionValues values;

        internal ShapesUpdateHueAction(INanoleafShapes shapes, ShapesUpdateHueActionValues values)
        {
            this.shapes = shapes;
            this.values = values;
        }

        public void Perform()
        {
            var request = new UpdateHueRequest(values.value, values.max, values.min);
            EndpointMessenger.UpdateStateRequest(shapes.URL, shapes.DeveloperAuthToken, request);
        }
    }
}

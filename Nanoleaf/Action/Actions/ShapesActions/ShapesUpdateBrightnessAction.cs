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
    public struct UpdateBrightnessActionValues
    {
        public int brightness;
        public int? duration;
        public UpdateBrightnessActionValues(int brightness, int? duration = null)
        {
            this.brightness = brightness;
            this.duration = duration;
        }
    }
    internal class ShapesUpdateBrightnessAction: IAction
    {
        private INanoleafShapes shapes;
        private UpdateBrightnessActionValues values;

        internal ShapesUpdateBrightnessAction(INanoleafShapes shapes, UpdateBrightnessActionValues values)
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

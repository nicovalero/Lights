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
using System.Threading;
using System.Collections;
using Nanoleaf.EffectConfig.Creators.Interfaces;
using Nanoleaf.Network.Structs;

namespace Nanoleaf.Action.Actions.ShapesActions
{
    internal struct ShapesUpdateHueActionValues
    {
        public double value;
        public ShapesUpdateHueActionValues(double value)
        {
            this.value = value;
        }
    }
    internal class ShapesUpdateHueAction: IAction
    {
        private List<INanoleafShapes> shapesList;
        private readonly UpdateHueRequest request;
        private IEffectConfigSet effectConfigSet;

        internal ShapesUpdateHueAction(List<INanoleafShapes> shapes, ShapesUpdateHueActionValues values, IEffectConfigSet config)
        {
            effectConfigSet = config;
            shapesList = shapes;
            request = new UpdateHueRequest(values.value);
        }

        public bool Perform()
        {
            foreach (var shapes in shapesList)
            {
                EndpointMessenger.UpdateStateRequest(shapes.URL, shapes.DeveloperAuthToken, request);
            }

            return true;
        }
    }
}

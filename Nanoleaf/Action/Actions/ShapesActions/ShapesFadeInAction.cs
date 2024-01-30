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
using Nanoleaf.EffectConfig.Creators.Classes;
using Nanoleaf.Action.Actions.ShapesPanelsActions;
using System.Threading;

namespace Nanoleaf.Action.Actions.ShapesActions
{
    internal class ShapesFadeInAction : IAction
    {
        private List<INanoleafShapes> shapesList;
        private UpdateBrightnessRequest request;

        internal ShapesFadeInAction(List<INanoleafShapes> shapesList, FadeInConfigSet set)
        {
            this.shapesList = shapesList;
            var brightness = (byte)set.BrightnessConfig.Value;

            request = new UpdateBrightnessRequest(brightness);
        }

        public bool Perform()
        {
            bool start = false;

            foreach (INanoleafShapes shapes in shapesList)
            {
                var thread = new Thread(
                () =>
                {
                    while (start != true)
                    { }
                    //Create Brightness request to finish the flow
                    EndpointMessenger.UpdateStateRequest(shapes.URL, shapes.DeveloperAuthToken, request);
                });
                thread.Start();
            }

            start = true;

            return true;
        }
    }
}

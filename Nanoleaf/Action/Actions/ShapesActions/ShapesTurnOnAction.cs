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
    internal class ShapesTurnOnAction : IAction
    {
        private List<INanoleafShapes> shapesList;
        private UpdateStateOnRequest request;

        internal ShapesTurnOnAction(List<INanoleafShapes> shapesList, TurnOnConfigSet set)
        {
            this.shapesList = shapesList;
            var on = (bool)set.TurnOnConfig.Value;

            request = new UpdateStateOnRequest(on);
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
                    EndpointMessenger.UpdateStateOnRequest(shapes.URL, shapes.DeveloperAuthToken, request);
                });
                thread.Start();
            }

            start = true;

            return true;
        }
    }
}

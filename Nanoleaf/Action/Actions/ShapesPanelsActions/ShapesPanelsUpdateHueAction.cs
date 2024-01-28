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
using System.Drawing;
using Nanoleaf.Converters;

namespace Nanoleaf.Action.Actions.ShapesPanelsActions
{    internal struct ShapesPanelsUpdateColorActionValues
    {
        public Color color;
        public ShapesPanelsUpdateColorActionValues(Color color)
        {
            this.color = color;
        }
    }

    internal class ShapesPanelsUpdateHueAction
    {
        private Dictionary<INanoleafShapes, UpdatePanelsColorRequest> shapesRequestDictionary;

        internal ShapesPanelsUpdateHueAction(Dictionary<IShapesPanel, INanoleafShapes> panelShapesDictionary, ShapesPanelsUpdateColorActionValues values)
        {
            var panelsByShapes = new Dictionary<INanoleafShapes, List<IShapesPanel>>();
            var hueValue = RGBToHueConverter.GetHue(values.color);

            foreach (var kvp in panelShapesDictionary)
            {
                if(!panelsByShapes.ContainsKey(kvp.Value))
                {
                    panelsByShapes.Add(kvp.Value, new List<IShapesPanel>());
                }
                panelsByShapes[kvp.Value].Add(kvp.Key);
                
            }

            foreach(var kvp in panelsByShapes)
            {
                var list = kvp.Value;
                var shapes = kvp.Key;

                var request = new UpdatePanelsColorRequest(list, hueValue);

                shapesRequestDictionary.Add(shapes, request);
            }
        }

        public void Perform()
        {
            
            foreach (var kvp in shapesRequestDictionary)
            {
                var shapes = kvp.Key;
                var request = kvp.Value;

                EndpointMessenger.UpdateStateRequest(shapes.URL, shapes.DeveloperAuthToken, request);
            }
        }
    }
}

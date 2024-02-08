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
using System.Threading;

namespace Nanoleaf.Action.Actions.ShapesPanelsActions
{
    internal struct ShapesPanelsColorWaveActionValues
    {
        public Queue<Tuple<IShapesPanel, ShapesUpdateEffectsActionValues>> panelsValuesQueue;
        public uint transitionTimeInMilliseconds;
        public ShapesPanelsColorWaveActionValues(Queue<Tuple<IShapesPanel, ShapesUpdateEffectsActionValues>> panelsValuesQueue, uint transitionTimeInMilliseconds)
        {
            this.panelsValuesQueue = panelsValuesQueue;
            this.transitionTimeInMilliseconds = transitionTimeInMilliseconds;
        }
    }

    internal struct ShapesPanelsColorRequestCombo
    {
        public INanoleafShapes shapes;
        public UpdateEffectsRequest request;
        public int transitionTimeInMilliseconds;

        internal ShapesPanelsColorRequestCombo(INanoleafShapes shapes, UpdateEffectsRequest request, uint transitionTimeInMilliseconds)
        {
            this.shapes = shapes;
            this.request = request;
            this.transitionTimeInMilliseconds = Convert.ToInt32(transitionTimeInMilliseconds);
        }
    }

    internal class ShapesPanelsColorWaveAction : IAction
    {
        [JsonProperty]
        private Queue<ShapesPanelsColorRequestCombo> panelShapesRequestQueue;

        [JsonConstructor]
        internal ShapesPanelsColorWaveAction() { }

        internal ShapesPanelsColorWaveAction(Dictionary<IShapesPanel, INanoleafShapes> panelShapesDictionary, ShapesPanelsColorWaveActionValues values)
        {
            panelShapesRequestQueue = new Queue<ShapesPanelsColorRequestCombo>();
            foreach (var panelValues in values.panelsValuesQueue)
            {
                var panel = panelValues.Item1;
                if (panelShapesDictionary.ContainsKey(panel))
                {
                    var shapes = panelShapesDictionary[panel];
                    var request = new UpdateEffectsRequest(panelValues.Item2);
                    var combo = new ShapesPanelsColorRequestCombo(shapes, request, values.transitionTimeInMilliseconds);
                    panelShapesRequestQueue.Enqueue(combo);
                }
            }
        }

        public bool Perform()
        {
            foreach (var combo in panelShapesRequestQueue)
            {
                var shapes = combo.shapes;
                var request = combo.request;

                EndpointMessenger.UpdateEffectsRequest(shapes.URL, shapes.DeveloperAuthToken, request);
                Thread.Sleep(combo.transitionTimeInMilliseconds);
            }

            return true;
        }
    }
}

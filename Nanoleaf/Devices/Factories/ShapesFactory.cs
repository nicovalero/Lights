using Nanoleaf.Devices.Classes;
using Nanoleaf.Devices.Enums;
using Nanoleaf.Devices.Interfaces;
using Nanoleaf.Network.Classes;
using Nanoleaf.Network.Classes.Responses;
using Nanoleaf.Network.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace Nanoleaf.Devices.Factories
{
    internal class ShapesFactory
    {
        private HashSet<INanoleafShapes> currentShapes;
        private ShapesPanelFactory shapesPanelFactory;

        public ShapesFactory()
        {
            currentShapes = new HashSet<INanoleafShapes>();
            shapesPanelFactory = new ShapesPanelFactory();
        }

        internal INanoleafShapes CreateShapes(Uri shapesUri)
        {
            try
            {
                //Uncomment when the save file saves the token.
                //var authTokenResponse = EndpointMessenger.SendNewDeveloperRequest(shapesUri).Result;

                //if (authTokenResponse != null)
                //{
                var devAuthObject = new DeveloperAuthToken("CckRCKFIS6gE3J8dYOtFfFCvZt7xxqv2"/*authTokenResponse.AuthToken*/);

                var panelLayoutResponse = EndpointMessenger.SendLayoutRequest(shapesUri, devAuthObject).Result;
                var panelSet = shapesPanelFactory.GetPanelsFromLayoutResponse(panelLayoutResponse);
                var controller = panelSet.Select(x => x)
                    .Where(x => x.GetShapeType() == ShapeType.ShapesController)
                    .FirstOrDefault();

                if (controller != null)
                {
                    var shapes = new Shapes(Convert.ToUInt32(controller.GetPanelID()), shapesUri, devAuthObject, panelSet);

                    return shapes;
                }
                //}
            }
            catch (Exception ex) { }

            return null;
        }
    }
}

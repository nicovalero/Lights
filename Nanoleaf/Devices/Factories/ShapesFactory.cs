using Nanoleaf.Devices.Classes;
using Nanoleaf.Devices.Enums;
using Nanoleaf.Devices.Interfaces;
using Nanoleaf.Network.Classes;
using Nanoleaf.Network.Classes.Responses;
using Nanoleaf.Network.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
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
                var authTokenResponse = EndpointMessenger.SendNewDeveloperRequest(shapesUri).Result;

                if (authTokenResponse != null)
                {
                    var devAuthObject = new DeveloperAuthToken(authTokenResponse.AuthToken);

                    var panelLayoutResponse = EndpointMessenger.SendLayoutRequest(shapesUri, devAuthObject).Result;
                    var panelSet = shapesPanelFactory.GetPanelsFromLayoutResponse(panelLayoutResponse);

                    var shapes = new Shapes(shapesUri, devAuthObject, panelSet);

                    return shapes;
                }
            }
            catch(Exception ex) { }

            return null;
        }
    }
}

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
        private IDeviceFinder deviceFinder;
        private HashSet<INanoleafShapes> currentShapes;

        public ShapesFactory()
        {
            this.deviceFinder = new DeviceFinder(ProcessBridgeRequestAnswer);
            currentShapes = new HashSet<INanoleafShapes>();
        }

        public HashSet<INanoleafShapes> GetAllShapes()
        {
            currentShapes.Clear();
            deviceFinder.FindAllmDNSMulticast();
            Thread.Sleep(5000);

            return currentShapes;
        }

        public HashSet<INanoleafShapes> GetAllShapes2()
        {
            currentShapes.Clear();
            currentShapes.Add(CreateShapes2());
            return currentShapes;
        }

        private void ProcessBridgeRequestAnswer(object sender, Uri deviceUri)
        {
            var shapes = CreateShapes(deviceUri);
            if(!currentShapes.Contains(shapes))
                currentShapes.Add(shapes);
        }
        private INanoleafShapes CreateShapes(Uri shapesUri)
        {
            var shapes = new Shapes(shapesUri);
            var authTokenResponse = GetUserForShapes(shapes);
            shapes.SetDeveloperAuthToken(new DeveloperAuthToken(authTokenResponse.AuthToken));

            return shapes;
        }

        private INanoleafShapes CreateShapes2()
        {
            var shapes = new Shapes(new Uri("http://192.168.1.9"));
            shapes.SetDeveloperAuthToken(new DeveloperAuthToken("CckRCKFIS6gE3J8dYOtFfFCvZt7xxqv2"));

            return shapes;
        }

        private DeveloperAuthTokenResponse GetUserForShapes(INanoleafShapes shapes)
        {
            var responseContent = EndpointMessenger.SendNewDeveloperRequest(shapes.GetURL()).Result;
            var authTokenResponse = JsonConvert.DeserializeObject<DeveloperAuthTokenResponse>(responseContent);
            return authTokenResponse;
        }
    }
}

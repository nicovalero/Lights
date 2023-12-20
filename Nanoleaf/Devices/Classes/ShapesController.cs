using Nanoleaf.Devices.Interfaces;
using Nanoleaf.Network;
using Nanoleaf.Network.Classes;
using Nanoleaf.Network.Classes.Responses;
using Nanoleaf.Network.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Nanoleaf.Devices.Classes
{
    internal class ShapesController
    {
        private IDeviceFinder deviceFinder;
        private Dictionary<string, INanoleafShapes> shapesDictionary;
        public List<INanoleafShapes> ShapesList { get; private set; }

        public ShapesController()
        {
            deviceFinder = new DeviceFinder(ProcessBridgeRequestAnswer);
            shapesDictionary = new Dictionary<string, INanoleafShapes>();
            ShapesList = new List<INanoleafShapes>();
        }

        public void LoadDevices()
        {
            ResetProperties();
            deviceFinder.FindAllmDNSMulticast();
            Thread.Sleep(5000);
        }

        private void ResetProperties()
        {
            shapesDictionary.Clear();
            ShapesList.Clear();
        }

        public void ConnectDevice(INanoleafShapes shapes)
        {
            if(!shapes.HasAuthToken())
            {
                var authTokenResponse = GetUserForShapes(shapes);
                shapes.SetDeveloperAuthToken(new DeveloperAuthToken(authTokenResponse.AuthToken));
            }
            shapes.Connect();
        }

        //public List<IShapesPanelModel> GetShapesPanels(INanoleafShapes shapes)
        //{

        //}

        private DeveloperAuthTokenResponse GetUserForShapes(INanoleafShapes shapes)
        {
            var responseContent = EndpointMessenger.SendNewDeveloperRequest(shapes.GetURL()).Result;
            var authTokenResponse = JsonConvert.DeserializeObject<DeveloperAuthTokenResponse>(responseContent);
            return authTokenResponse;
        }

        private void ProcessBridgeRequestAnswer(object sender, INanoleafShapes device)
        {
            ConnectDevice(device);
            ShapesList.Add(device);
        }
    }
}

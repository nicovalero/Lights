using Nanoleaf.Devices.Interfaces;
using Nanoleaf.Network.Classes;
using Nanoleaf.Network.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nanoleaf.Devices.Classes
{
    internal class ShapesController
    {
        private IDeviceFinder deviceFinder;
        private Dictionary<string, INanoleafShapes> shapesDictionary;
        private List<INanoleafShapes> shapesList;

        public ShapesController()
        {
            deviceFinder = new DeviceFinder(ProcessBridgeRequestAnswer);
            shapesDictionary = new Dictionary<string, INanoleafShapes>();
            shapesList = new List<INanoleafShapes>();
        }

        public void InitializeDevices()
        {
            ResetProperties();
            deviceFinder.FindAllmDNSMulticast();
        }

        private void ResetProperties()
        {
            shapesDictionary.Clear();
            shapesList.Clear();
        }

        private void ConnectDevice(INanoleafShapes shapes)
        {
            shapes.Connect();
        }

        private void ProcessBridgeRequestAnswer(object sender, INanoleafShapes device)
        {
            shapesList.Add(device);
            ConnectDevice(device);
        }
    }
}

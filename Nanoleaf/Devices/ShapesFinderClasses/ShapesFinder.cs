using Nanoleaf.Devices.Interfaces;
using Nanoleaf.Network.Classes;
using Nanoleaf.Network.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Nanoleaf.Devices.ShapesFinderClasses
{
    internal class ShapesFinder
    {
        private IDeviceFinder deviceFinder;
        internal EventHandler<Uri> FoundControllerHandler;

        public ShapesFinder()
        {
            this.deviceFinder = new DeviceFinder(ProcessControllerRequestAnswer);
        }

        public void FindShapesControllers()
        {
            deviceFinder.FindAllmDNSMulticast();
            Thread.Sleep(5000);
        }

        private void ProcessControllerRequestAnswer(object sender, Uri deviceUri)
        {
            FoundControllerHandler(this, deviceUri);
        }
    }
}

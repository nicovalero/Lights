using Nanoleaf.Action.Classes;
using Nanoleaf.Devices.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nanoleaf
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var controller = new ShapesController();
            
            controller.LoadDevices();

            var shapes = controller.ShapesList[0];
            var actionController = new ActionController();

            var allLightControllerInfoResponse = actionController.GetShapesPanelList(shapes);
        }
    }
}

using Nanoleaf.Action.Classes;
using Nanoleaf.Devices.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nanoleaf.Devices.Classes
{
    internal class PanelController
    {
        private readonly INanoleafShapes shapes;
        private HashSet<IShapesPanel> panels;
        private ActionController actionController;
        private IShapesPanelFactory shapesPanelFactory;

        public PanelController(INanoleafShapes shapes, ActionController actionController, IShapesPanelFactory shapesPanelFactory)
        {
            this.shapesPanelFactory = shapesPanelFactory;
            this.actionController = actionController;
            this.shapes = shapes;

            //var allLightControllerInfoResponse = actionController.GetAllLightControllerInfo(shapes);
            //panels = shapesPanelFactory.GetPanelSet(allLightControllerInfoResponse);
        }
    }
}

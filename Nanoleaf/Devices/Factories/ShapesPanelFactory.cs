using Nanoleaf.Devices.Interfaces;
using Nanoleaf.Devices.ShapesPanelLayoutClasses;
using Nanoleaf.Network.Classes;
using Nanoleaf.Network.Classes.Responses;
using Nanoleaf.Network.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Nanoleaf.Devices.Classes
{
    public class ShapesPanelFactory
    {
        //public HashSet<IShapesPanel> GetPanelSet(AllLightControllerInfoResponse response)
        //{
        //    var panels = new HashSet<IShapesPanel>();

        //    var layout = response.PanelLayout.layout;

        //    foreach(var data in layout.PositionData)
        //    {
        //        var newPanel = new ShapesPanel(data.PanelId.ToString(), data.O.ToString(), data.X.ToString(), data.Y.ToString());
        //        if(!panels.Contains(newPanel))
        //        {
        //            panels.Add(newPanel);
        //        }
        //    }

        //    return panels;
        //}

        //public HashSet<IShapesPanel> GetPanelSet(ShapesLayout response)
        //{

        //}

        internal HashSet<IShapesPanel> GetPanelsFromLayoutResponse(ShapesLayout layoutResponse)
        {
            var panels = new HashSet<IShapesPanel>();
            var positionData = layoutResponse.PositionData;

            foreach (var data in positionData)
            {
                var newPanel = new ShapesPanel(data.PanelId.ToString(), data.O.ToString(), data.X.ToString(), data.Y.ToString());
                if (!panels.Contains(newPanel))
                {
                    panels.Add(newPanel);
                }
            }

            return panels;
        }

        public IShapesPanel CreatePanelFromID(string id)
        {
            var newPanel = new ShapesPanel(id);

            return newPanel;
        }
    }
}

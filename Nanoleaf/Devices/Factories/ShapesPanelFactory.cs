using Nanoleaf.Devices.Interfaces;
using Nanoleaf.Network.Classes.Responses;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nanoleaf.Devices.Classes
{
    internal class ShapesPanelFactory
    {
        public HashSet<IShapesPanel> GetPanelSet(AllLightControllerInfoResponse response)
        {
            var panels = new HashSet<IShapesPanel>();

            var layout = response.PanelLayout.layout;

            foreach(var data in layout.PositionData)
            {
                var newPanel = new ShapesPanel(data.PanelId.ToString(), data.O.ToString(), data.X.ToString(), data.Y.ToString());
                if(!panels.Contains(newPanel))
                {
                    panels.Add(newPanel);
                }
            }

            return panels;
        }
    }
}

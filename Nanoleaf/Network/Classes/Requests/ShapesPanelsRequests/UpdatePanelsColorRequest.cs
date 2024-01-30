using Nanoleaf.Devices.Interfaces;
using Nanoleaf.Devices.ShapesEffects;
using Nanoleaf.Devices.ShapesPanelLayoutClasses;
using Nanoleaf.Devices.ShapesRhythm;
using Nanoleaf.Devices.ShapesStateClasses;
using Nanoleaf.Network.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nanoleaf.Network.Classes.Requests.ShapesRequests
{
    internal class UpdateColorRequestAttribute
    {
        [JsonProperty("value")]
        public int color { get; set; }
        public UpdateColorRequestAttribute(int color)
        {
            this.color = color;
        }
    }

    internal class UpdatePanelsColorRequest: IUpdateStateRequest
    {
        [JsonProperty("hue")]
        public UpdateColorRequestAttribute Hue { get; set; }

        public UpdatePanelsColorRequest(List<IShapesPanel> panels, int value)
        {
            Hue = new UpdateColorRequestAttribute(value);
        }

        public string GetSerializedJson()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}

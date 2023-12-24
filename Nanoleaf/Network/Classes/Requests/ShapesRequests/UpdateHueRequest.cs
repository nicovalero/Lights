using Nanoleaf.Devices.ShapesEffects;
using Nanoleaf.Devices.ShapesPanelLayoutClasses;
using Nanoleaf.Devices.ShapesRhythm;
using Nanoleaf.Devices.ShapesStateClasses;
using Nanoleaf.Network.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nanoleaf.Network.Classes.Requests.ShapesRequests
{
    internal class UpdateHueRequestAttribute
    {
        [JsonProperty("value")]
        public int Value { get; set; }

        [JsonProperty("max")]
        public int Max { get; set; }

        [JsonProperty("min")]
        public int Min { get; set; }
        public UpdateHueRequestAttribute(int value, int max, int min)
        {
            Value = value;
            Min = min;
            Max = max;
        }
    }

    internal class UpdateHueRequest: IUpdateStateRequest
    {
        [JsonProperty("hue")]
        public UpdateHueRequestAttribute Hue { get; set; }

        public UpdateHueRequest(int value, int max, int min)
        {
            Hue = new UpdateHueRequestAttribute(value, max, min);
        }

        public string GetSerializedJson()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}

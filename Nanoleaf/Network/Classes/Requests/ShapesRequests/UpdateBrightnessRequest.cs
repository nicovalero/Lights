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
    internal class UpdateBrightnessRequestAttribute
    {
        [JsonProperty("value")]
        public int Value { get; set; }

        [JsonProperty("duration", NullValueHandling = NullValueHandling.Ignore)]
        public int? Duration { get; set; }
        public UpdateBrightnessRequestAttribute(int value, int? duration)
        {
            Value = value;
            Duration = duration;
        }
    }

    internal class UpdateBrightnessRequest: IUpdateStateRequest
    {
        [JsonProperty("brightness")]
        public UpdateBrightnessRequestAttribute Brightness { get; set; }

        public UpdateBrightnessRequest(int value, int? duration = null)
        {
            Brightness = new UpdateBrightnessRequestAttribute(value, duration);
        }

        public string GetSerializedJson()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}

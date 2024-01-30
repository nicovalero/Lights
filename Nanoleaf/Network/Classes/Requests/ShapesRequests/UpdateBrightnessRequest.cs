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
        public byte Value { get; set; }

        [JsonProperty("duration", NullValueHandling = NullValueHandling.Ignore)]
        public int? Duration { get; set; }
        public UpdateBrightnessRequestAttribute(byte value, int? duration)
        {
            Value = value;
            Duration = duration;
        }
    }

    internal class UpdateBrightnessRequest: IUpdateStateRequest
    {
        [JsonProperty("brightness")]
        public UpdateBrightnessRequestAttribute Brightness { get; set; }

        public UpdateBrightnessRequest(byte brightness, int? duration = null)
        {
            Brightness = new UpdateBrightnessRequestAttribute(brightness, duration);
        }

        public string GetSerializedJson()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}

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
    internal class UpdateStateOnRequestAttribute
    {
        [JsonProperty("value")]
        public bool Value { get; set; }
        public UpdateStateOnRequestAttribute(bool value)
        {
            Value = value;
        }
    }

    internal class UpdateStateOnRequest : IUpdateStateRequest
    {
        [JsonProperty("on")]
        public UpdateStateOnRequestAttribute On { get; set; }

        public UpdateStateOnRequest(bool isOn)
        {
            On = new UpdateStateOnRequestAttribute(isOn);
        }

        public string GetSerializedJson()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}

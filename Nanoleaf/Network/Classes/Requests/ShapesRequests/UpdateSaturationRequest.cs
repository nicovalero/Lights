using Nanoleaf.Action.Actions.ShapesActions;
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
    internal class UpdateSaturationRequestAttribute
    {
        [JsonProperty("value")]
        public int Value { get; set; }
        public UpdateSaturationRequestAttribute(int value)
        {
            Value = value;
        }
    }

    internal class UpdateSaturationRequest: IUpdateSaturationRequest
    {
        [JsonProperty("sat")]
        public UpdateSaturationRequestAttribute Sat { get; set; }

        public UpdateSaturationRequest(ShapesUpdateSaturationActionValues values)
        {
            Sat = new UpdateSaturationRequestAttribute(values.value);
        }

        public string GetSerializedJson()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}

﻿using Nanoleaf.Devices.ShapesEffects;
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
        public double Value { get; set; }
        public UpdateHueRequestAttribute(double value)
        {
            Value = value;
        }
    }

    internal class UpdateHueRequest: IUpdateStateRequest
    {
        [JsonProperty("hue")]
        public UpdateHueRequestAttribute Hue { get; set; }

        public UpdateHueRequest(double value)
        {
            Hue = new UpdateHueRequestAttribute(value);
        }

        public string GetSerializedJson()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}

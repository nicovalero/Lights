﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nanoleaf.Devices.ShapesPanelLayoutClasses
{
    public class ShapesPositionData
    {
        [JsonProperty("panelId")]
        public int PanelId { get; set; }

        [JsonProperty("x")]
        public int X { get; set; }

        [JsonProperty("y")]
        public int Y { get; set; }

        [JsonProperty("O")]
        public int O { get; set; }

        [JsonProperty("shapeType")]
        public int ShapeType { get; set; }
    }
}

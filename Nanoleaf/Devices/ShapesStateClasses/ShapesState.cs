using Nanoleaf.Devices.ShapesStateClasses;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nanoleaf.Devices.ShapesStateClasses
{
    public class ShapesState
    {
        [JsonProperty("on")]
        public ShapesStateOn On { get; set; }

        [JsonProperty("brightness")]
        public ShapesStateBrightness Brightness { get; set; }

        [JsonProperty("hue")]
        public ShapesStateHue Hue { get; set; }

        [JsonProperty("sat")]
        public ShapesStateSat Sat { get; set; }

        [JsonProperty("ct")]
        public ShapesStateSat CT { get; set; }

        [JsonProperty("colorMode")]
        public string ColorMode { get; set; }
    }
}

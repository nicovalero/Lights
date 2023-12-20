using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nanoleaf.Devices.ShapesStateClasses
{
    public class ShapesStateOn
    {
        [JsonProperty("value")]
        public bool Value { get; set; }
    }
}

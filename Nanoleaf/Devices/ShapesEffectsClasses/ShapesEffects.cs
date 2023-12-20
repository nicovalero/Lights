using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nanoleaf.Devices.ShapesEffects
{
    public class ShapesEffects
    {
        [JsonProperty("select")]
        public string Select { get; set; }

        [JsonProperty("effectsList")]
        public string[] EffectsList { get; set; }
    }
}

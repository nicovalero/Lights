using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nanoleaf.Devices.ShapesPanelLayoutClasses
{
    public class ShapesPanelLayout
    {
        [JsonProperty("layout")]
        public ShapesLayout layout { get; set; }

        [JsonProperty("globalOrientation")]
        public ShapesGlobalOrientation globalOrientation { get; set; }
    }
}

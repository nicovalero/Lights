using Newtonsoft.Json;

namespace Nanoleaf.Devices.ShapesPanelLayoutClasses
{
    public class ShapesGlobalOrientation
    {
        [JsonProperty("value")]
        public int Value { get; set; }

        [JsonProperty("max")]
        public int Max { get; set; }

        [JsonProperty("min")]
        public int Min { get; set; }
    }
}
using Newtonsoft.Json;

namespace Nanoleaf.Devices.ShapesPanelLayoutClasses
{
    public class ShapesLayout
    {
        [JsonProperty("numPanels")]
        public int NumPanels { get; set; }

        [JsonProperty("sideLength")]
        public int SideLength { get; set; }

        [JsonProperty("positionData")]
        public ShapesPositionData[] PositionData { get; set; }
    }
}
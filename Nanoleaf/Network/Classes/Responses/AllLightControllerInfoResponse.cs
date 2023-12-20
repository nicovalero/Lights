using Nanoleaf.Devices.Classes;
using Nanoleaf.Devices.ShapesEffects;
using Nanoleaf.Devices.ShapesPanelLayoutClasses;
using Nanoleaf.Devices.ShapesRhythm;
using Nanoleaf.Devices.ShapesStateClasses;
using Nanoleaf.Network.Interfaces;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Nanoleaf.Network.Classes.Responses
{
    internal class AllLightControllerInfoResponse: IResponse
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("serialNo")]
        public string SerialNo { get; set; }

        [JsonProperty("manufacturer")]
        public string Manufacturer { get; set; }

        [JsonProperty("firmwareVersion")]
        public string FirmwareVersion { get; set; }

        [JsonProperty("model")]
        public string Model { get; set; }

        [JsonProperty("state")]
        public ShapesState State { get; set; }

        [JsonProperty("effects")]
        public ShapesEffects Effects { get; set; }

        [JsonProperty("panelLayout")]
        public ShapesPanelLayout PanelLayout { get; set; }

        [JsonProperty("rhythm")]
        public ShapesRhythm Rhythm { get; set; }
    }
}

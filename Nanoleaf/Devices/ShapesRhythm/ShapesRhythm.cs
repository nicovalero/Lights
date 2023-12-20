using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nanoleaf.Devices.ShapesRhythm
{
    public class ShapesRhythm
    {
        [JsonProperty("rhythmConnected")]
        public bool RhythmConnected { get; set; }

        [JsonProperty("rhythmActive")]
        public string RhythmActive { get; set; }

        [JsonProperty("rhythmId")]
        public string RhythmId { get; set; }

        [JsonProperty("hardwareVersion")]
        public string HardwareVersion { get; set; }

        [JsonProperty("firmwareVersion")]
        public string FirmwareVersion { get; set; }

        [JsonProperty("auxAvailable")]
        public string AuxAvailable { get; set; }

        [JsonProperty("rhythmMode")]
        public string RhythmMode { get; set; }

        [JsonProperty("rhythmPos")]
        public string RhythmPos { get; set; }
    }
}

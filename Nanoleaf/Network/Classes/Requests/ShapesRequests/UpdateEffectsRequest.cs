using Nanoleaf.Action.Actions.ShapesActions;
using Nanoleaf.Action.Actions.ShapesPanelsActions;
using Nanoleaf.Devices.ShapesEffects;
using Nanoleaf.Devices.ShapesPanelLayoutClasses;
using Nanoleaf.Devices.ShapesRhythm;
using Nanoleaf.Devices.ShapesStateClasses;
using Nanoleaf.Network.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nanoleaf.Network.Classes.Requests.ShapesRequests
{
    internal class UpdateEffectsRequestAttribute
    {
        [JsonProperty("command")]
        public string Command { get; set; }

        [JsonProperty("version")]
        public string Version { get; set; }

        [JsonProperty("animType")]
        public string AnimType { get; set; }

        [JsonProperty("animData")]
        public string AnimData { get; set; }

        [JsonProperty("loop")]
        public bool Loop { get; set; }

        [JsonProperty("palette")]
        public string[] Palette { get; set; }

        public UpdateEffectsRequestAttribute(string command, string version, string animType, string animData,
            bool loop, string[] palette)
        {
            Command = command;
            Version = version;
            AnimType = animType;
            AnimData = animData;
            Loop = loop;
            Palette = palette;
        }
    }

    internal class UpdateEffectsRequest: IUpdateEffectsRequest
    {
        [JsonProperty("write")]
        public UpdateEffectsRequestAttribute Write { get; set; }

        public UpdateEffectsRequest(ShapesUpdateEffectsActionValues values)
        {
            Write = new UpdateEffectsRequestAttribute(values.Command, values.Version, values.AnimType, values.AnimDataString, values.Loop, values.Palette);
        }

        public string GetSerializedJson()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}

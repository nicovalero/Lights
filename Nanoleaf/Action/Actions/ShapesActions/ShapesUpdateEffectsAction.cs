using Nanoleaf.Action.Interfaces;
using Nanoleaf.Devices.Classes;
using Nanoleaf.Network.Classes.Responses;
using Nanoleaf.Network.Classes;
using Nanoleaf.Network.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nanoleaf.Devices.Interfaces;
using Nanoleaf.Network.Classes.Requests.ShapesRequests;

namespace Nanoleaf.Action.Actions.ShapesActions
{
    internal struct ShapesUpdateEffectsActionValues
    {
        public string Command { get; set; }
        public string Version { get; set; }
        public string AnimType { get; set; }
        public string AnimData { get; set; }
        public bool Loop { get; set; }
        public string[] Palette { get; set; }
        public ShapesUpdateEffectsActionValues(string command, string version, string animType, string animData,
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
    internal class ShapesUpdateEffectsAction
    {
        private INanoleafShapes shapes;
        private ShapesUpdateEffectsActionValues values;

        internal ShapesUpdateEffectsAction(INanoleafShapes shapes, ShapesUpdateEffectsActionValues values)
        {
            this.shapes = shapes;
            this.values = values;
        }

        public void Perform()
        {
            var request = new UpdateEffectsRequest(values);
            EndpointMessenger.UpdateEffectsRequest(shapes.GetURL(), shapes.GetDeveloperAuthToken(), request);
        }
    }
}

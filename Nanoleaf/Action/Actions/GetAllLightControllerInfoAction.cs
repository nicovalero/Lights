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

namespace Nanoleaf.Action.Actions
{
    internal class GetAllLightControllerInfoAction
    {
        private INanoleafShapes shapes;
        public GetAllLightControllerInfoAction(INanoleafShapes shapes)
        {
            this.shapes = shapes;
        }
        public AllLightControllerInfoResponse Perform()
        {
            var responseContent = EndpointMessenger.GetAllLightControllerInfoRequest(shapes.URL, shapes.DeveloperAuthToken).Result;
            var response = JsonConvert.DeserializeObject<AllLightControllerInfoResponse>(responseContent);
            return response;
        }
    }
}

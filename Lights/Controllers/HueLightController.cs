using PhilipsHueAPI.Models.Classes;
using PhilipsHueAPI.Models.Enums;

namespace PhilipsHueAPI.Controllers
{
    public class HueLightController
    {
        private readonly HueBridgeV2 bridge;

        public HueLightController(HueBridgeV2 bridge)
        {
            this.bridge = bridge;
            bridge.Connect();
        }

        public void ChangeLightState(string id, HueState state, List<HueJSONBodyStateProperty> properties)
        {
            bridge.ChangeLightState(id, state, properties);
        }
    }
}

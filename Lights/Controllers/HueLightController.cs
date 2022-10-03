using PhilipsHueAPI.Models.Classes;
using PhilipsHueAPI.Models.Enums;

namespace PhilipsHueAPI.Controllers
{
    public class HueLightController
    {
        private static readonly HueLightController _controller = new HueLightController();
        private HueBridgeV2 _bridge;

        private HueLightController()
        {

        }

        public static HueLightController GetSingleton()
        {
            return _controller;
        }

        public void SetBridge(HueBridgeV2 newBridge)
        {
            this._bridge = newBridge;
            this._bridge.Connect();
        }

        public void ChangeLightState(string id, HueState state, List<HueJSONBodyStateProperty> properties)
        {
            _bridge.ChangeLightState(id, state, properties);
        }
    }
}

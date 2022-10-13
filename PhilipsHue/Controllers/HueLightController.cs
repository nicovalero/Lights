using PhilipsHue.Models.Classes;
using PhilipsHue.Models.Enums;
using PhilipsHue.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;

namespace PhilipsHue.Controllers
{
    public class HueLightController
    {
        private static readonly HueLightController _controller = new HueLightController();
        private BridgeV2Finder _bridgeV2Finder;
        private Bridge _bridge;

        private HueLightController()
        {
            _bridgeV2Finder = new BridgeV2Finder();
            List<Bridge> bridges = _bridgeV2Finder.FindAll().Result;

            if(bridges.Count > 0)
                SetBridge(bridges[0]);
        }

        public static HueLightController Singleton()
        {
            return _controller;
        }

        public void SetBridge(Bridge newBridge)
        {
            this._bridge = newBridge;
            this._bridge.Connect();
        }

        public async Task ChangeLightState(string id, HueState state, List<HueJSONBodyStateProperty> properties)
        {
            await _bridge.ChangeLightState(id, state, properties);
        }
    }
}

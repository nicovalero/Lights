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
        private Dictionary<string, Bridge> _lightBridgeDictionary;

        private HueLightController()
        {
            _bridgeV2Finder = new BridgeV2Finder();
            _lightBridgeDictionary = new Dictionary<string, Bridge>();

            InitializeBridges();
        }

        private async void InitializeBridges()
        {
            List<Bridge> bridges = await _bridgeV2Finder.FindAll();
            _lightBridgeDictionary = new Dictionary<string, Bridge>();

            foreach (Bridge bridge in bridges)
            {
                ConnectBridge(bridge);
                foreach (HueLight light in bridge.GetAllLights())
                {
                    _lightBridgeDictionary.Add(light.uniqueId, bridge);
                }
            }
        }

        public static HueLightController Singleton()
        {
            return _controller;
        }

        private void ConnectBridge(Bridge bridge)
        {
            bridge.Connect();
        }

        public async Task ChangeLightState(string uniqueid, HueState state, List<HueJSONBodyStateProperty> properties)
        {
            if(_lightBridgeDictionary.ContainsKey(uniqueid))
                await _lightBridgeDictionary[uniqueid].ChangeLightState(uniqueid, state, properties);
        }
    }
}

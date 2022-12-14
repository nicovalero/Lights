using PhilipsHue.Models;
using PhilipsHue.Models.Classes;
using PhilipsHue.Models.Enums;
using PhilipsHue.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace PhilipsHue.Controllers
{
    public class HueLightController
    {
        private static readonly HueLightController _controller = new HueLightController();
        private BridgeV2Finder _bridgeV2Finder;
        private Dictionary<string, Bridge> _lightBridgeDictionary;
        private List<Bridge> _bridgeList;

        private HueLightController()
        {
            _bridgeV2Finder = new BridgeV2Finder(ProcessBridgeRequestAnswer);
            _lightBridgeDictionary = new Dictionary<string, Bridge>();
            _bridgeList = new List<Bridge>();
        }

        public void InitializeBridges()
        {
            ResetProperties();
            _bridgeV2Finder.FindAllmDNSMulticast();
        }

        private void ResetProperties()
        {
            _lightBridgeDictionary.Clear();
            _bridgeList.Clear();
        }

        public static HueLightController Singleton()
        {
            return _controller;
        }

        private void ConnectBridge(Bridge bridge)
        {
            bridge.Connect();
        }

        public async Task ChangeLightState(string uniqueid, HueStateJSONProperty combo)
        {
            HueState state = combo.State;
            List<HueJSONBodyStateProperty> properties = combo.JsonProperties.ToList();
            if (_lightBridgeDictionary.ContainsKey(uniqueid))
                await _lightBridgeDictionary[uniqueid].ChangeLightState(uniqueid, state, properties);
        }

        public List<HueLight> GetAllLightsList()
        {
            List<HueLight> list = new List<HueLight>();

            foreach (Bridge bridge in _bridgeList)
            {
                list.AddRange(bridge.GetAllLights());
            }

            return list;
        }

        public int GetBridgeCount()
        {
            return _bridgeList.Count;
        }

        private void ProcessBridgeRequestAnswer(object sender, Bridge bridge)
        {
            _bridgeList.Add(bridge);
            ConnectBridge(bridge);
            foreach (HueLight light in bridge.GetAllLights())
            {
                if (!_lightBridgeDictionary.ContainsKey(light.uniqueId))
                    _lightBridgeDictionary.Add(light.uniqueId, bridge);
            }
        }
    }
}

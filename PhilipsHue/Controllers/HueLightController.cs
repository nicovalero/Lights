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
            _bridgeV2Finder = new BridgeV2Finder();
            _lightBridgeDictionary = new Dictionary<string, Bridge>();
            _bridgeList = new List<Bridge>();
        }

        public void InitializeBridges()
        {
            //Exchange FindAllManual with FindAll when the issues
            //of discovering the bridges dynamically are over.

            //List<Bridge> bridges = await _bridgeV2Finder.FindAll();
            List<Bridge> bridges = _bridgeV2Finder.FindAllManual();
            _lightBridgeDictionary = new Dictionary<string, Bridge>();
            ResetProperties();

            foreach (Bridge bridge in bridges)
            {
                _bridgeList.Add(bridge);
                ConnectBridge(bridge);
                foreach (HueLight light in bridge.GetAllLights())
                {
                    _lightBridgeDictionary.Add(light.uniqueId, bridge);
                }
            }
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

        public async Task ChangeLightState(string uniqueid, HueState state, List<HueJSONBodyStateProperty> properties)
        {
            if(_lightBridgeDictionary.ContainsKey(uniqueid))
                await _lightBridgeDictionary[uniqueid].ChangeLightState(uniqueid, state, properties);
        }

        public List<HueLight> GetAllLightsList()
        {
            List<HueLight> list = new List<HueLight>();

            foreach(Bridge bridge in _bridgeList)
            {
                list.AddRange(bridge.GetAllLights());
            }

            return list;
        }

        public int GetBridgeCount()
        {
            return _bridgeList.Count;
        }
    }
}

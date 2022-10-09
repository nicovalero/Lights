﻿using PhilipsHue.Models.Classes;
using PhilipsHue.Models.Enums;
using System;
using System.Collections.Generic;

namespace PhilipsHue.Controllers
{
    public class HueLightController
    {
        private static readonly HueLightController _controller = new HueLightController();
        private HueBridgeV2 _bridge;

        private HueLightController()
        {
            HueBridgeV2 bridge = new HueBridgeV2(new Uri("http://192.168.1.213"));
            SetBridge(bridge);
        }

        public static HueLightController Singleton()
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

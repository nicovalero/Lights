using Microsoft.AspNetCore.SignalR;
using Newtonsoft.Json;
using PhilipsHueAPI.Models.Enums;
using PhilipsHueAPI.Models.Interfaces;
using System;
using System.Text;

namespace PhilipsHueAPI.Models.Classes
{
    public class HueColorLight : HueLight
    {
        private HueState _state;
        private HueSWUpdate _swupdate;
        private string _type;
        private string _name;
        private string _modelId;
        private string _manufacturerName;
        private string _productName;
        private HueCapabilities _capabilities;
        private HueLightConfig _config;
        private string _uniqueId;
        private string _swVersion;
        private string _swConfigId;
        private string _productId;

        public HueState state { get { return _state; } set { _state = value; } }
        public HueSWUpdate swupdate { get { return _swupdate; } set { _swupdate = value; } }
        public string type { get { return _type; } set { _type = value; } }
        public string name { get { return _name; } set { _name = value; } }
        public string modelId { get { return _modelId; } set { _modelId = value; } }
        public string manufacturerName { get { return _manufacturerName; } set { _manufacturerName = value; } }
        public string productName { get { return _productName; } set { _productName = value; } }
        public HueCapabilities capabilities { get { return _capabilities; } set { _capabilities = value; } }
        public HueLightConfig config { get { return _config; } set { _config = value; } }
        public string uniqueId { get { return _uniqueId; } set { _uniqueId = value; } }
        public string swVersion { get { return _swVersion; } set { _swVersion = value; } }
        public string swConfigId { get { return _swConfigId; } set { _swConfigId = value; } }
        public string productId { get { return _productId; } set { _productId = value; } }

        public HueColorLight()
        {
            this._state = new HueState();
            this._swupdate = new HueSWUpdate();
            this._type = "";
            this._name = "";
            this._modelId = "";
            this._manufacturerName = "";
            this._productName = "";
            this._capabilities = new HueCapabilities();
            this._config = new HueLightConfig();
            this._uniqueId = "";
            this._swVersion = "";
            this._swConfigId = "";
            this._productId = "";
        }

        public HueColorLight(HueState state, HueSWUpdate swupdate, string type, string name, string modelId, string manufacturerName, string productName, HueCapabilities capabilities, HueLightConfig config, string uniqueId, string swVersion, string swConfigId, string productId)
        {
            this._state = state;
            this._swupdate = swupdate;
            this._type = type;
            this._name = name;
            this._modelId = modelId;
            this._manufacturerName = manufacturerName;
            this._productName = productName;
            this._capabilities = capabilities;
            this._config = config;
            this._uniqueId = uniqueId;
            this._swVersion = swVersion;
            this._swConfigId = swConfigId;
            this._productId = productId;
        }

        public string GetUniqueId()
        {
            return uniqueId;
        }

        public HueState GetState()
        {
            return state;
        }

        public void SetState(HueState state)
        {
            this.state = state;
        }

        public bool IsOn()
        {
            throw new NotImplementedException();
        }

        public bool IsReachable()
        {
            throw new NotImplementedException();
        }

        public void Switch(bool on)
        {
            throw new NotImplementedException();
        }

        public void ChangeStateProperties(HueState state, List<HueJSONBodyStateProperty> properties)
        {
            foreach(HueJSONBodyStateProperty property in properties)
            {
                switch (property)
                {
                    case HueJSONBodyStateProperty.ON:
                        this.state.on = state.on;
                        break;
                    case HueJSONBodyStateProperty.BRI:
                        this.state.bri = state.bri;
                        break;
                    case HueJSONBodyStateProperty.HUE:
                        this.state.hue = state.hue;
                        break;
                    case HueJSONBodyStateProperty.SAT:
                        this.state.sat = state.sat;
                        break;
                    case HueJSONBodyStateProperty.EFFECT:
                        this.state.effect = state.effect;
                        break;
                    case HueJSONBodyStateProperty.XY:
                        this.state.xy = state.xy;
                        break;
                    case HueJSONBodyStateProperty.CT:
                        this.state.ct = state.ct;
                        break;
                    case HueJSONBodyStateProperty.ALERT:
                        this.state.alert = state.alert;
                        break;
                    case HueJSONBodyStateProperty.COLORMODE:
                        this.state.colorMode = state.colorMode;
                        break;
                    case HueJSONBodyStateProperty.MODE:
                        this.state.mode = state.mode;
                        break;
                    case HueJSONBodyStateProperty.REACHABLE:
                        this.state.reachable = state.reachable;
                        break;
                    default:
                        break;
                }
            }
        }
    }
}

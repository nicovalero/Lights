using Newtonsoft.Json;
using PhilipsHueAPI.Models.Enums;
using PhilipsHueAPI.Models.Interfaces;
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
            this.state.SetOn(on);
        }
    }
}

using PhilipsHueAPI.Models.Classes;

namespace PhilipsHueAPI.Models.Interfaces
{
    public interface HueLight
    {
        public HueState state { get; set; }
        public HueSWUpdate swupdate{ get; set; }
        public string type{ get; set; }
        public string name{ get; set; }
        public string modelId{ get; set; }
        public string manufacturerName{ get; set; }
        public string productName{ get; set; }
        public HueCapabilities capabilities{ get; set; }
        public HueLightConfig config{ get; set; }
        public string uniqueId{ get; set; }
        public string swVersion{ get; set; }
        public string swConfigId{ get; set; }
        public string productId{ get; set; }

        public HueState GetState();
        public void SetState(HueState state);
        public bool IsReachable();
        public bool IsOn();
        public void Switch(bool on);

    }
}

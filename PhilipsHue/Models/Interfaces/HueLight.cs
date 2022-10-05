using PhilipsHue.Models.Classes;
using PhilipsHue.Models.Enums;
using System.Collections.Generic;

namespace PhilipsHue.Models.Interfaces
{
    public interface HueLight
    {
        HueState state { get; set; }
        HueSWUpdate swupdate{ get; set; }
        string type{ get; set; }
        string name{ get; set; }
        string modelId{ get; set; }
        string manufacturerName{ get; set; }
        string productName{ get; set; }
        HueCapabilities capabilities{ get; set; }
        HueLightConfig config{ get; set; }
        string uniqueId{ get; set; }
        string swVersion{ get; set; }
        string swConfigId{ get; set; }
        string productId{ get; set; }

        HueState GetState();
        void SetState(HueState state);
        bool IsReachable();
        bool IsOn();
        void Switch(bool on);
        void ChangeStateProperties(HueState state, List<HueJSONBodyStateProperty> properties);

    }
}

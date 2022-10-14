using PhilipsHue.Models.Classes;
using PhilipsHue.Models.Enums;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PhilipsHue.Models.Interfaces
{
    public interface Bridge
    {
        bool Connect();
        void AddScene(int key, Scene scene);
        void AddLight(string key, HueLight light);
        void AddGroup(int key, Group Group);
        HueLight GetLight(string id);
        List<HueLight> GetAllLights();
        Task ChangeLightState(string id, HueState state, List<HueJSONBodyStateProperty> properties);
    }
}

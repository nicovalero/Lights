using Microsoft.AspNetCore.Builder;
using PhilipsHueAPI.Controllers;
using PhilipsHueAPI.Models.Classes;
using PhilipsHueAPI.Models.Enums;

namespace PhilipsHueAPI
{
    public static class Startup
    {
        static ManualResetEvent _quitEvent = new ManualResetEvent(false);
        public static void Main()
        {
            Console.CancelKeyPress += (sender, eArgs) => {
                _quitEvent.Set();
                eArgs.Cancel = true;
            };

            HueBridgeV2 bridge = new HueBridgeV2(new Uri("http://192.168.1.213"));
            HueLightController hueLightController = new HueLightController(bridge);

            HueState state = new HueState();
            state.on = false;

            List<HueJSONBodyStateProperty> list = new List<HueJSONBodyStateProperty>();
            list.Add(HueJSONBodyStateProperty.ON);

            hueLightController.ChangeLightState("3", state, list);

            _quitEvent.WaitOne();
        }
    }
}

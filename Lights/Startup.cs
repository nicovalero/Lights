using Microsoft.AspNetCore.Builder;
using PhilipsHueAPI.Controllers;
using PhilipsHueAPI.Effects.Classes;
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
            HueLightController hueLightController = HueLightController.Singleton();
            hueLightController.SetBridge(bridge);

            FadeIn fadeIn = FadeIn.Singleton();
            FadeOut fadeOut = FadeOut.Singleton();
            ColorChange colorChange = ColorChange.Singleton();
            Flash flash = Flash.Singleton();

            for (int i = 0; i < 50; i++)
            {
                flash.Perform("3");
                Thread.Sleep(200);
            }

            _quitEvent.WaitOne();
        }
    }
}

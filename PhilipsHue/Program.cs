using PhilipsHue.Controllers;
using PhilipsHue.Effects.Classes;
using PhilipsHue.Models.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PhilipsHue
{
    internal class Program
    {
        static ManualResetEvent _quitEvent = new ManualResetEvent(false);
        static void Main(string[] args)
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

            List<string> ids = new List<string>();
            ids.Add("3");

            for (int i = 0; i < 50; i++)
            {
                flash.Perform(ids);
                Thread.Sleep(50);
            }

            _quitEvent.WaitOne();
        }
    }
}

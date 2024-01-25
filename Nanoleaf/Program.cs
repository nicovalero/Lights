using Nanoleaf.Action.Actions.ShapesActions;
using Nanoleaf.Action.Classes;
using Nanoleaf.Devices.Classes;
using Nanoleaf.Devices.Factories;
using Nanoleaf.Devices.Interfaces;
using Nanoleaf.Network.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Nanoleaf
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //var actionController = new ActionController();
            //var shapesFactory = new ShapesFactory();

            //var shapes = shapesFactory.GetAllShapes().ToList()[0];
            //var shapesController = new ShapesController(actionController, shapes);

            //var info = actionController.GetAllLightControllerInfo(shapes);

            //var allQueue = new Queue<int>(new int[] { 10611, 30854, 32394, 20223, 664, 50437, 29715, 13167, 13681, 4585, 42622, 36735, 15748, 9770, 41225, 10281, 19613, 13644, 29543, 2428, 4912, 28194, 34156, 19147, 43935, 13253, 60617, 9488, 19046, 51565, 26553, 41986 });
            //var bigTrianglesList = new List<int>(new int[] { 32394, 29715, 34156, 19046 });

            //Thread.Sleep(10000);

            //shapesController.UpdateBrightness(new UpdateBrightnessActionValues(50));

            //Thread.Sleep(1000);

            //var rnd = new Random();

            ////10611 30854 32394 B 20223 664 50437 29715 B 13167 13681 4585 42622 36735 15748 9770 41225 10281 19613 13644 29543 2428 4912 28194 34156 B 19147 43935 13253 60617 9488 19046 B 51565 26553 41986
            //for (int i = 0; i < 10; i++)
            //{
            //    var currentQueue = new Queue<int>(allQueue);
            //    var R = rnd.Next(0, 255);
            //    var B = rnd.Next(0, 255);
            //    var G = rnd.Next(0, 255);
            //    while (currentQueue.Count > 0)
            //    {
            //        shapesController.UpdateEffects(new ShapesUpdateEffectsActionValues("display", "2.0", "static", "1 " + currentQueue.Dequeue() + " 1 " + R + " " + G + " " + B + " 0 3", false, new List<string>().ToArray()));
            //        Thread.Sleep(200);
            //    }
            //    Thread.Sleep(3000);
            //}
        }
    }
}

using Nanoleaf.Devices.Interfaces;
using System;
using System.Security.Policy;

namespace Nanoleaf.Devices.Classes
{
    internal class Shapes: INanoleafShapes
    {
        public Uri URL { get; set; }

        public Shapes(Uri uRL)
        {
            URL = uRL;
        }

        public void Connect()
        {
            
        }
    }
}

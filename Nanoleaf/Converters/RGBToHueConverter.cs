using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nanoleaf.Converters
{
    internal static class RGBToHueConverter
    {
        internal static double GetHue(Color color)
        {
            double calcR = color.R / 255.0;
            var calcG = color.G / 255.0;
            var calcB = color.B / 255.0;
            var max = Math.Max(Math.Max(calcR, calcG), calcB);
            var min = Math.Min(Math.Min(calcR, calcG), calcB);

            double hue = 0;

            if (min != max)
            {
                switch (max)
                {
                    case var value when value == calcR:
                        hue = (calcG - calcB) / (max - min);
                        break;
                    case var value when value == calcG:
                        hue = 2.0 + (calcB - calcR) / (max - min);
                        break;
                    case var value when value == calcB:
                        hue = 4.0 + (calcR - calcG) / (max - min);
                        break;
                }

                hue = hue * 60;
                hue = (hue < 0 ? hue + 360 : hue);
            }

            return hue;
        }
    }
}

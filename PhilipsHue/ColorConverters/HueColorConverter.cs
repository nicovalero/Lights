using System;
using System.Collections.Generic;
using System.Linq;
using SystemMath = System.Math;
using System.Drawing;

namespace PhilipsHue.ColorConverters
{
    public static class HueColorConverter
    {
        public static Dictionary<string,double> TransformRGBtoXY(Color c)
        {
            // For the hue bulb the corners of the triangle are:
            // -Red: 0.675, 0.322
            // -Green: 0.4091, 0.518
            // -Blue: 0.167, 0.04
            double[] normalizedToOne = new double[3];
            float cred, cgreen, cblue;
            cred = c.R;
            cgreen = c.G;
            cblue = c.B;
            normalizedToOne[0] = (cred / 255);
            normalizedToOne[1] = (cgreen / 255);
            normalizedToOne[2] = (cblue / 255);
            float red, green, blue;

            // Make red more vivid
            if (normalizedToOne[0] > 0.04045)
            {
                red = (float)Math.Pow(
                        (normalizedToOne[0] + 0.055) / (1.0 + 0.055), 2.4);
            }
            else
            {
                red = (float)(normalizedToOne[0] / 12.92);
            }

            // Make green more vivid
            if (normalizedToOne[1] > 0.04045)
            {
                green = (float)Math.Pow((normalizedToOne[1] + 0.055)
                        / (1.0 + 0.055), 2.4);
            }
            else
            {
                green = (float)(normalizedToOne[1] / 12.92);
            }

            // Make blue more vivid
            if (normalizedToOne[2] > 0.04045)
            {
                blue = (float)Math.Pow((normalizedToOne[2] + 0.055)
                        / (1.0 + 0.055), 2.4);
            }
            else
            {
                blue = (float)(normalizedToOne[2] / 12.92);
            }

            float X = (float)(red * 0.649926 + green * 0.103455 + blue * 0.197109);
            float Y = (float)(red * 0.234327 + green * 0.743075 + blue * 0.022598);
            float Z = (float)(red * 0.0000000 + green * 0.053077 + blue * 1.035763);

            float x = X / (X + Y + Z);
            float y = Y / (X + Y + Z);

            double[] xy = new double[2];
            xy[0] = x;
            xy[1] = y;
            Dictionary<string, double> map = new Dictionary<string, double>();
            map.Add("x", x);
            map.Add("y", y);
            return map;
        }
    }
}

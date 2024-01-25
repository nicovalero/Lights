using Nanoleaf.EffectConfig.Products.Interfaces;
using Nanoleaf.EffectConfig.Enums;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nanoleaf.EffectConfig.Products.Classes
{
    public class ColorConfig : IEffectPropertyConfig
    {
        private Color _rgbColor;
        public Color RGBColor { get { return _rgbColor; } set { _rgbColor = value; } }
        public string JsonProperty { get { return null;/*return JSONBodyStateProperty.XY;*/ } }
        public object Value
        {
            get
            {
                return _rgbColor;
            }
            set
            {
                if (value != null)
                {
                    if (value is Color)
                        _rgbColor = (Color)value;
                }
            }
        }

        public ColorConfig(Color rgbColor)
        {
            _rgbColor = rgbColor;
        }
    }
}

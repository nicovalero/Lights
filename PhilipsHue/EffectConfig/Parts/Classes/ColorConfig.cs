using PhilipsHue.EffectConfig.Products.Interfaces;
using PhilipsHue.Models.Enums;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhilipsHue.EffectConfig.Products.Classes
{
    public class ColorConfig : IEffectPropertyConfig
    {
        private const string XKEY = "x";
        private const string YKEY = "y";
        private const HueJSONBodyStateProperty _JSONPROPERTY = HueJSONBodyStateProperty.XY;
        public HueJSONBodyStateProperty JsonProperty { get { return _JSONPROPERTY; } }
        private Dictionary<string, double> _xy;
        public object Value
        {
            get
            {
                return _xy;
            }
            set
            {
                if (value != null)
                {
                    if (value is Dictionary<string, double>)
                        _xy = (Dictionary<string, double>)value;
                }
            }
        }

        public ColorConfig(double x, double y)
        {
            _xy = new Dictionary<string, double>();
            _xy.Add(XKEY, x);
            _xy.Add(YKEY, y);
        }
    }
}

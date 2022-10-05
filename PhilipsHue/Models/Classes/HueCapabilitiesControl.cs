using System.Collections.Generic;

namespace PhilipsHue.Models.Classes
{
    public class HueCapabilitiesControl
    {
        public int minDimLevel;
        public int maxLumen;
        public string colorGamutType;
        public List<List<float>> colorGamut;
        public Dictionary<string, int> ct;

        public HueCapabilitiesControl()
        {
            ct = new Dictionary<string, int>();
            colorGamut = new List<List<float>>();
            colorGamutType = "";
            maxLumen = 0;
            minDimLevel = 0;
        }

        public HueCapabilitiesControl(int minDimLevel, int maxLumen, string colorGamutType, List<List<float>> colorGamut, Dictionary<string, int> ct)
        {
            this.minDimLevel = minDimLevel;
            this.maxLumen = maxLumen;
            this.colorGamutType = colorGamutType;
            this.colorGamut = colorGamut;
            this.ct = ct;
        }
    }
}

namespace PhilipsHueAPI.Models.Classes
{
    public class HueState
    {
        public bool on;
        public int bri;
        public int hue;
        public int sat;
        public string effect;
        public List<float> xy;
        public int ct;
        public string alert;
        public string colorMode;
        public string mode;
        public bool reachable;

        public HueState()
        {
            this.on = false;
            this.bri = 0;
            this.hue = 0;
            this.sat = 0;
            this.effect = "";
            this.xy = new List<float>();
            this.ct = 0;
            this.alert = "";
            this.colorMode = "";
            this.mode = "";
            this.reachable = false;
        }

        public HueState(bool on, int bri, int hue, int sat, string effect, List<float> xy, int ct, string alert, string colorMode, string mode, bool reachable)
        {
            this.on = on;
            this.bri = bri;
            this.hue = hue;
            this.sat = sat;
            this.effect = effect;
            this.xy = xy;
            this.ct = ct;
            this.alert = alert;
            this.colorMode = colorMode;
            this.mode = mode;
            this.reachable = reachable;
        }
    }
}

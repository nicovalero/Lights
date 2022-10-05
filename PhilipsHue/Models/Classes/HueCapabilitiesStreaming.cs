namespace PhilipsHue.Models.Classes
{
    public class HueCapabilitiesStreaming
    {
        public bool renderer;
        public bool proxy;

        public HueCapabilitiesStreaming()
        {
            renderer = false;
            proxy = false;
        }

        public HueCapabilitiesStreaming(bool renderer, bool proxy)
        {
            this.renderer = renderer;
            this.proxy = proxy;
        }
    }
}

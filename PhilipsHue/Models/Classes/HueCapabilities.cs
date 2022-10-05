namespace PhilipsHue.Models.Classes
{
    public class HueCapabilities
    {
        public string certified;
        public HueCapabilitiesControl control;
        public HueCapabilitiesStreaming streaming;

        public HueCapabilities()
        {
            this.certified = "";
            this.control = new HueCapabilitiesControl();
            this.streaming = new HueCapabilitiesStreaming();
        }

        public HueCapabilities(string certified, HueCapabilitiesControl control, HueCapabilitiesStreaming streaming)
        {
            this.certified = certified;
            this.control = control;
            this.streaming = streaming;
        }
    }
}

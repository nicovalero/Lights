namespace PhilipsHue.Models.Classes
{
    public class HueLightConfigStartup
    {
        public string mode;
        public bool configured;

        public HueLightConfigStartup()
        {
            this.mode = "";
            this.configured = false;
        }

        public HueLightConfigStartup(string mode, bool configured)
        {
            this.mode = mode;
            this.configured = configured;
        }
    }
}

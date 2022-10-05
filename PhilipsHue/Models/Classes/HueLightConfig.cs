namespace PhilipsHue.Models.Classes
{
    public class HueLightConfig
    {
        public string archetype;
        public string function;
        public string direction;
        public HueLightConfigStartup startup;

        public HueLightConfig()
        {
            this.archetype = "";
            this.function = "";
            this.direction = "";
            this.startup = new HueLightConfigStartup();
        }

        public HueLightConfig(string archetype, string function, string direction, HueLightConfigStartup startup)
        {
            this.archetype = archetype;
            this.function = function;
            this.direction = direction;
            this.startup = startup;
        }
    }
}

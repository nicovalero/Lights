namespace PhilipsHueAPI.Models.Classes
{
    public class HueSWUpdate
    {
        public string state;
        public string lastInstall;

        public HueSWUpdate()
        {
            this.state = "";
            this.lastInstall = "";
        }

        public HueSWUpdate(string state, string lastInstall)
        {
            this.state = state;
            this.lastInstall = lastInstall;
        }
    }
}

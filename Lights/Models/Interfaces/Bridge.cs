namespace PhilipsHueAPI.Models.Interfaces
{
    public interface Bridge
    {
        public bool Connect();
        public void AddScene(int key, Scene scene);
        public void AddLight(string key, HueLight light);
        public void AddGroup(int key, Group Group);
        public HueLight GetLight(string id);
    }
}

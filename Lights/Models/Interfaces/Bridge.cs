namespace PhilipsHueAPI.Models.Interfaces
{
    public interface Bridge
    {
        public bool Connect();
        public void AddScene(int key, Scene scene);
        public void AddLight(int key, Light light);
        public void AddGroup(int key, Group Group);
    }
}

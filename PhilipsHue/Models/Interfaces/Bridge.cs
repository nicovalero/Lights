namespace PhilipsHue.Models.Interfaces
{
    public interface Bridge
    {
        bool Connect();
        void AddScene(int key, Scene scene);
        void AddLight(string key, HueLight light);
        void AddGroup(int key, Group Group);
        HueLight GetLight(string id);
    }
}

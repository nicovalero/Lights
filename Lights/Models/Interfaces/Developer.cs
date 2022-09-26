using PhilipsHueAPI.Models.Enums;

namespace PhilipsHueAPI.Models.Interfaces
{
    public interface Developer
    {
        public string GetUsername();
        public string GetDeviceType();
        public Task<bool> SetNewDeveloperAsync(Uri URL, HueEndpoint endpoint);
    }
}

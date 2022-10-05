using PhilipsHue.Models.Enums;
using System;
using System.Threading.Tasks;

namespace PhilipsHue.Models.Interfaces
{
    public interface Developer
    {
        string GetUsername();
        string GetDeviceType();
        Task<bool> SetNewDeveloperAsync(Uri URL, HueEndpointKey endpoint);
    }
}

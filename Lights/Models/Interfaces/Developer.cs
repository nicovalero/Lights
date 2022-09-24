namespace PhilipsHueAPI.Models.Interfaces
{
    public interface Developer
    {
        public string GetName();
        public Task<bool> SetNewDeveloperAsync(HueEndpoint URL);
    }
}

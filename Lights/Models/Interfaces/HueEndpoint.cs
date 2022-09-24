namespace PhilipsHueAPI.Models.Interfaces
{
    public interface HueEndpoint
    {
        public HttpMethod GetHttpMethod();
        public string GetEndpointPath();
    }
}

using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Nanoleaf.Network.Classes.Responses
{
    internal class DeveloperAuthTokenResponse
    {
        [JsonProperty("auth_token")]
        public string AuthToken { get; set; }
    }
}

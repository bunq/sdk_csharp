using Newtonsoft.Json;

namespace Bunq.Sdk.Model
{
    public class SessionToken
    {
        [JsonProperty(PropertyName = "token")]
        public string Token { get; private set; }

        public SessionToken(string token)
        {
            Token = token;
        }
    }
}

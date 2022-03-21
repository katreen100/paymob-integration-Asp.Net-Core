using Newtonsoft.Json;

namespace paymob.Models.paymobModels.FristSttep
{
    public class AuthTokenResponse
    {
        [JsonProperty("token")]
        public string ?Token { get; set; }
    }
}

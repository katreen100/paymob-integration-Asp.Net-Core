using Newtonsoft.Json;

namespace paymob.Models.paymobModels.FristSttep
{
    public class ApiKey
    {
        [JsonProperty("api-key")]
        public string Key { set; get; }
    }
}
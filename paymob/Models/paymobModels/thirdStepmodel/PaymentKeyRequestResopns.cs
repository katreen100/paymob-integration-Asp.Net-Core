using Newtonsoft.Json;

namespace paymob.Models.paymobModels.thirdStepmodel
{
    public class PaymentKeyRequestResopns
    {
        [JsonProperty("token")]
        public string? Token { get; set; }
    }
}

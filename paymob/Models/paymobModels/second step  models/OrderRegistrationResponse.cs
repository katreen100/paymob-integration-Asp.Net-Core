using Newtonsoft.Json;

namespace paymob.Models.paymobModels.second_step__models
{
    public class OrderRegistrationResponse
    {
        [JsonProperty("id")]
        public string? Id { get; set; }  
    }
}

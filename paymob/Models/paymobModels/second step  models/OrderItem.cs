using Newtonsoft.Json;

namespace paymob.Models.paymobModels.second_step__models
{
    public class OrderItem
    {
        [JsonProperty("name")]
        public string? Name { get; set; }
        [JsonProperty("amount_cents")]
        public string? AmountCents { get; set; }
        [JsonProperty("description")]
        public string? Description { get; set; }
        [JsonProperty("quantity")]
        public int Quantity { get; set; }

    }
}

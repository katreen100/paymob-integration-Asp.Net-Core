using Newtonsoft.Json;

namespace paymob.Models.paymobModels.thirdStepmodel
{
    public class BillingData
    {
        [JsonProperty("apartment")]
        public string ? Apartment { get; set; }
        [JsonProperty("email")]
        public string ? Email { get; set; }
        [JsonProperty("floor")]
        public string ? Floor { get; set; }
        [JsonProperty("first_name")]
        public string ? FirstName { get; set; }
        [JsonProperty("street")]
        public string ? Street { get; set; }
        [JsonProperty("building")]
        public string ? Building { get; set; }
        [JsonProperty("phone_number")]
        public string ? PhoneNumber { get; set; }
        [JsonProperty("shipping_metho")]
        public string?  ShippingMethod { get; set; }
        [JsonProperty("postal_code")]
        public string ? PostalCode { get; set; }
        [JsonProperty("city")]
        public string ? City { get; set; }
        [JsonProperty("country")]
        public string ? Country { get; set; }
        [JsonProperty("last_name")]
        public string ? LastName { get; set; }
        [JsonProperty("stat")]
        public string ? State { get; set; }
    }
}

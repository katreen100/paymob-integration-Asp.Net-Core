using Newtonsoft.Json;
using paymob.Models.paymobModels;
using paymob.Models.paymobModels.FristSttep;
using paymob.Models.paymobModels.second_step__models;
using paymob.Models.paymobModels.thirdStepmodel;
using System.Text;

namespace paymob.HttpServices
{
    public class HttpServiceAsyncAwait :IHttpServiceAsyncAwait 
    {
        private readonly IConfiguration _configuration;
        private readonly HttpClient _client;

        public HttpServiceAsyncAwait(IConfiguration configuration, IHttpClientFactory http)
        {
            _configuration = configuration;
            _client = http.CreateClient();
        }
        public async Task<string> GetToken()
        {
            try
            {
                string URL = "https://accept.paymob.com/api/auth/tokens";
                string apikey = _configuration.GetValue<string>("api_key");
                var keyobject = new { api_key = apikey };
                var seralizedobj = new StringContent(JsonConvert.SerializeObject(keyobject), Encoding.UTF8, "application/json");
                var response = await _client.PostAsync(URL, seralizedobj);
                if (response.IsSuccessStatusCode)
                {
                    var data = await response.Content.ReadAsStringAsync();
                    var obj = JsonConvert.DeserializeObject<AuthTokenResponse>(data);
                    if (obj is not null)
                        if(obj.Token is not null)
                    return obj.Token;
                    return "error message";
                }
                return "error";
             
            }
            catch (Exception ex)
            {
                // if (ex.InnerException != null)
                // throw ex.InnerException;
                // throw  ex.Message.ToString();
                return ex.Message;


            }
          
        }

        public async Task<string> OrderRegistation(string token)
        {
            try { 
            string URL = "https://accept.paymob.com/api/ecommerce/orders";
            List<OrderItem> items = new();
            items.Add(new OrderItem
            {
                Name = "consultation",
                AmountCents = "35000",
                Description = "consultatoion",
                Quantity = 1
            });

            var RequestedData = new OrderRegistrationitem
            {
                AmountCents = 35000,
                AuthToken = token,
                DeliveryNeeded = false,
                Currency = "EGP",
                Items = items
            };
            var SerializedRequestedObj = new StringContent(JsonConvert.SerializeObject(RequestedData), Encoding.UTF8, "application/json");
            var response = await _client.PostAsync(URL, SerializedRequestedObj);
            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadAsStringAsync();
                var obj = JsonConvert.DeserializeObject<OrderRegistrationResponse>(data);
                if (obj is not null)
                   if(obj.Id is not null)
                    return obj.Id;
                return "error";
            }
            return "error";
        }
            catch(Exception ex)
            {
                return ex.Message;
            }
        }

        public async Task<string> PaymentKey(string token, string orderId)
        {
            try {
                var URL = "https://accept.paymob.com/api/acceptance/payment_keys";
                var RequestedData = new PaymentKeyRequestData
                {
                    AuthToken = token,
                    AmountContent = 35000,
                    Expiration = 4000,
                    OrderId = orderId,
                    //l mafrod ab3t l obj ll function ??
                    BillingData = new BillingData
                    {
                        Apartment = "shobra",
                        Email = "katy@email.com",
                        Floor = "6",
                        FirstName = "katreen",
                        Street = "street",
                        Building = "25",
                        PhoneNumber = "01200012122",
                        ShippingMethod = "shiping",
                        PostalCode = "d",
                        City = "tahta",
                        Country = "sohage",
                        LastName = "ebraheem",
                        State = "state"
                    },
                    Currency = "EGP",
                    IntegrationId = _configuration.GetValue<int>("integration-Id")
                };
                var SerializedRequestedObj = new StringContent(JsonConvert.SerializeObject(RequestedData), Encoding.UTF8, "application/json");
                var response = await _client.PostAsync(URL, SerializedRequestedObj);
                if (response.IsSuccessStatusCode) {
                    var data = await response.Content.ReadAsStringAsync();
                    var obj = JsonConvert.DeserializeObject<PaymentKeyRequestResopns>(data);
                    if (obj != null)
                    {
                        if (obj.Token is not null)
                            return obj.Token;
                    }
                    else
                    {
                        return "error";
                    }
                }
                return "error";


            }
            catch(Exception ex)
            {
                return ex.Message;
            }
            }
        
    }
}

namespace paymob.HttpServices
{
    public interface IHttpServiceAsyncAwait
    {
        public  Task<string> GetToken();
        public Task<string> OrderRegistation(string token);
        public Task<string> PaymentKey(string token, string orderId);

    }
}

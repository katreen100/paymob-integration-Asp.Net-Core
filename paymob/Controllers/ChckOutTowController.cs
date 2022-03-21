using Microsoft.AspNetCore.Mvc;
using paymob.HttpServices;
using paymob.Models.paymobModels;
using paymob.Models.paymobModels.FristSttep;
using paymob.Models.paymobModels.second_step__models;
using paymob.Models.paymobModels.thirdStepmodel;

namespace paymob.Controllers
{
    public class ChckOutTowController : Controller
    {
        private readonly IHttpServiceAsyncAwait _service;

        public ChckOutTowController(IHttpServiceAsyncAwait service )
        {
            _service = service;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Checkout()
        {
             var Tokenobj =  await _service.GetToken();
            var  objwithID = await _service.OrderRegistation (Tokenobj);
            var  IframToken = await _service.PaymentKey(Tokenobj, objwithID);
            return Redirect("https://accept.paymob.com/api/acceptance/iframes/359402?payment_token=" + IframToken);

        }
        [HttpGet]
        public IActionResult PaymentCallBack([FromQuery] bool Success)
        {
            if (Success)
            {
             return View();
            }
            return View("failed");
        }
    }
}

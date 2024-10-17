using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Store.Reposatrys.Basket.Models;
using Store.Serveses.PaymentService;
using Stripe;

namespace Store.Web.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentService paymentService;
        const string endPointSecret = " whsec_b2d604d44cd523f394eb3aa0b00af80c391e13b5c69bcac29ca93fa528dfe356"

        public PaymentController(IPaymentService paymentService)
        {
            this.paymentService = paymentService;
        }
        [HttpPost]
        public async Task<ActionResult<UserBasket>> CreateOrUpdatePayment(UserBasket userBasket)
        => Ok(await paymentService.createOrUpdatePaymentIntent(userBasket));

        [HttpPost]
        public async Task<IActionResult> HandleStripeWebhook()
        {
            var json = await new StreamReader(HttpContext.Request.Body).ReadToEndAsync();
            try
            {
                var stripeEvent = EventUtility.ConstructEvent(
                    json, Request.Headers["Stripe-Signature"], endPointSecret
                );
                PaymentIntent paymentIntent;
                if (stripeEvent.Type == "payment_intent.succeeded")
                {

                    paymentIntent = stripeEvent.Data.Object as PaymentIntent;

                    await paymentService.updatePaymentIntentSucced(paymentIntent.Id);

                }

                else if (stripeEvent.Type == "payment_intent.created")
                {
                    // التعامل مع فشل الدفع
                }

                else if (stripeEvent.Type == "payment_intent.failed")
                {
                    paymentIntent = stripeEvent.Data.Object as PaymentIntent;

                    await paymentService.updatePaymentIntentFailed(paymentIntent.Id);
                }

                return Ok();
            }
            catch (StripeException e)
            {
                return BadRequest();
            }
        }
    }
}

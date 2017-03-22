using System.Web.Http;
using System.Web.Http.Cors;
using AmountToText.Service;
using AmountToText.Web.Models;

namespace AmountToText.Web.Controllers.Api
{
    [EnableCors("*", "*", "*")]
    [RoutePrefix("api/TextConversion")]
    public class TextConversionController : ApiController
    {
        private readonly IAmountToTextService _amountToTextService;

        public TextConversionController(IAmountToTextService amountToTextService)
        {
            _amountToTextService = amountToTextService;
        }

        [HttpPost]
        public IHttpActionResult Index(ConversionRequest model)
        {
            var request = new ConversionInfo {Amount = model.Amount, Name = model.Name};
            var result = _amountToTextService.Convert(request);

            if (result == null)
            {
                // or internal server ?
                return BadRequest();
            }
            else
            {
                return Ok(result);
            }
        }
    }
}

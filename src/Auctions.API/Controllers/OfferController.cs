using Auctions.API.Communication.Requests;
using Auctions.API.Filter;
using Auctions.API.UseCase.Offers.CreateOffer;
using Microsoft.AspNetCore.Mvc;

namespace Auctions.API.Controllers
{
    [ServiceFilter(typeof(AuthenticationUserAttribute))]
    public class OfferController : AuctionBaseController
    {
        [HttpPost]
        [Route("{itemId}")]        
        public IActionResult CrerateOffer([FromRoute]int itemId, [FromBody]RequestCreateOfferJson request, [FromServices]CreateOfferUserCase useCase)
        {
            var id = useCase.Execute(itemId, request);
            return Created(string.Empty, id);
        }
    }
}

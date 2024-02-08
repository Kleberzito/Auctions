using Auctions.API.Entities;
using Auctions.API.UseCase.Auctions.GetCurrent;
using Microsoft.AspNetCore.Mvc;

namespace Auctions.API.Controllers
{
    public class AuctionController : AuctionBaseController
    {
        [HttpGet]
        [ProducesResponseType(typeof(Auction), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public IActionResult GetCurrent() 
        {
            var useCase = new AuctionUseCase();
            var result = useCase.Execute();

            if (result is null)
                return NoContent();

            return Ok(result);
        } 
    }
}

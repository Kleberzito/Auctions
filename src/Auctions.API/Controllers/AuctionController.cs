using Auctions.API.UseCase.Auctions.GetCurrent;
using Microsoft.AspNetCore.Mvc;

namespace Auctions.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AuctionController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetCurrent() 
        {
            var useCase = new AuctionUseCase();
            var result = useCase.Execute();

            return Ok(result);
        }
    }
}

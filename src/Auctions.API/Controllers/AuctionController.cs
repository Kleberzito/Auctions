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
            return Ok("kleber");
        }
    }
}

using Auctions.API.Entities;

namespace Auctions.API.UseCase.Auctions.GetCurrent
{
    public class AuctionUseCase
    {        
        public Auction Execute()
        {
            return new Auction
            {
                Id = 1,
                Ends = DateTime.Now,
                Starts = DateTime.Now,
                Name = "Test"
            };
        }
    }
}

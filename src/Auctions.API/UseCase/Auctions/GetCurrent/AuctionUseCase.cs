using Auctions.API.Entities;
using Auctions.API.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Auctions.API.UseCase.Auctions.GetCurrent
{
    public class AuctionUseCase
    {        
        public Auction? Execute()
        {
            var repository = new AuctionDbContext();

            var today = DateTime.Now;

            return repository
                .Auctions.Include(auction => auction.Items)
                .FirstOrDefault(auction => today >= auction.Starts && today <= auction.Ends);
        }
    }
}

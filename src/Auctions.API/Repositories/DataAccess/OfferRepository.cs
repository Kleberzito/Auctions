using Auctions.API.Contracts;
using Auctions.API.Entities;

namespace Auctions.API.Repositories.DataAccess
{
    public class OfferRepository : IOfferRepository
    {
        private readonly AuctionDbContext _dbContext;
        public OfferRepository(AuctionDbContext dbContext) => _dbContext = dbContext;
        public void Add(Offer offer)
        {
            _dbContext.Offers.Add(offer);
            _dbContext.SaveChanges();
        }
    }
}

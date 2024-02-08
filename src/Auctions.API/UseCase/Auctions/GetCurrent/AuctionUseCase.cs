using Auctions.API.Contracts;
using Auctions.API.Entities;

namespace Auctions.API.UseCase.Auctions.GetCurrent
{
    public class AuctionUseCase
    {
        private readonly IAuctionRepository _repository;

        public AuctionUseCase(IAuctionRepository repository) => _repository = repository;
        public Auction? Execute()
        {
            return _repository.GetCurrent();
        }
    }
}

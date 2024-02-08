using Auctions.API.Communication.Requests;
using Auctions.API.Entities;
using Auctions.API.Repositories;
using Auctions.API.Services;

namespace Auctions.API.UseCase.Offers.CreateOffer
{   
    public class CreateOfferUserCase
    {
        private readonly LoggedUser _loggedUser;
        public CreateOfferUserCase(LoggedUser loggedUser) => _loggedUser = loggedUser;
        public int Execute(int itemId, RequestCreateOfferJson resquest)
        {
            var repository = new AuctionDbContext();
            var user = _loggedUser.User();

            var offer = new Offer
            {
                CreatedOn = DateTime.Now,
                ItemId = itemId,
                Price = resquest.Price,
                UserId = user.Id,
            };

            repository.Offers.Add(offer);
            repository.SaveChanges();

            return offer.Id;
           
        }
    }
}

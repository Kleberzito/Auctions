using Auctions.API.Communication.Requests;
using Auctions.API.Contracts;
using Auctions.API.Entities;
using Auctions.API.Repositories;
using Auctions.API.Services;

namespace Auctions.API.UseCase.Offers.CreateOffer
{   
    public class CreateOfferUserCase
    {
        private readonly ILoggedUser _loggedUser;
        private readonly IOfferRepository _repository;
        public CreateOfferUserCase(ILoggedUser loggedUser, IOfferRepository repository)
        {
            _loggedUser = loggedUser;
            _repository = repository;
        }
        public int Execute(int itemId, RequestCreateOfferJson resquest)
        {
            var user = _loggedUser.User();

            var offer = new Offer
            {
                CreatedOn = DateTime.Now,
                ItemId = itemId,
                Price = resquest.Price,
                UserId = user.Id,
            };
            
            _repository.Add(offer);

            return offer.Id;
           
        }
    }
}

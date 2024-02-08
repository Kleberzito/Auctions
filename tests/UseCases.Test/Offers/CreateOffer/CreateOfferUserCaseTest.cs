using Auctions.API.Communication.Requests;
using Auctions.API.Contracts;
using Auctions.API.Entities;
using Auctions.API.Services;
using Auctions.API.UseCase.Offers.CreateOffer;
using Bogus;
using FluentAssertions;
using Moq;
using Xunit;

namespace UseCases.Test.Offers.CreateOffer
{
    public class CreateOfferUserCaseTest
    {
        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        public void Success(int itemId)
        {
            var request = new Faker<RequestCreateOfferJson>()
                .RuleFor(request => request.Price, f => f.Random.Decimal(1, 100)).Generate();

            var offerRepository = new Mock<IOfferRepository>();
            var loggedUser = new Mock<ILoggedUser>();
            loggedUser.Setup(i => i.User()).Returns(new User());

            var useCase = new CreateOfferUserCase(loggedUser.Object, offerRepository.Object);

            var act = () => useCase.Execute(itemId, request);

            act.Should().NotThrow();
        }
    }
}

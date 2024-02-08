using Auctions.API.Contracts;
using Auctions.API.Entities;
using Auctions.API.Enums;
using Auctions.API.UseCase.Auctions.GetCurrent;
using Bogus;
using FluentAssertions;
using Moq;
using Xunit;

namespace UseCases.Test.Auctions.GetCurrent
{
    public class AuctionsUseCaseTest
    {
        [Fact]
        public void Success()
        {
            var entity = new Faker<Auction>()
                .RuleFor(auction => auction.Id, f => f.Random.Number(1, 100))
                .RuleFor(auction => auction.Name, f => f.Lorem.Word())
                .RuleFor(auction => auction.Starts, f => f.Date.Past())
                .RuleFor(auction => auction.Ends, f => f.Date.Future())
                .RuleFor(auction => auction.Items, (f, auction) => new List<Item>
                {
                    new Item
                    {
                        Id = f.Random.Number(1, 100),
                        Name = f.Commerce.ProductName(),
                        Brand = f.Commerce.Department(),
                        BasePrice = f.Random.Decimal(50, 1000),
                        Condition = f.PickRandom<Condition>(),
                        AuctionId = auction.Id
                    }
                }).Generate();

            var mock = new Mock<IAuctionRepository>();
            mock.Setup(i => i.GetCurrent()).Returns(entity);

            var useCase = new AuctionUseCase(mock.Object);
            
            var auction = useCase.Execute();

            auction.Should().NotBeNull();
            auction.Id.Should().Be(entity.Id);
            auction.Name.Should().Be(entity.Name);
        }
    }
}

using Auctions.API.Contracts;
using Auctions.API.Entities;

namespace Auctions.API.Repositories.DataAccess
{
    public class UserRepository : IUserRepository
    {
        private readonly AuctionDbContext _dbContext;
        public UserRepository(AuctionDbContext dbContext) => _dbContext = dbContext;
        public bool ExistUserWithEMail(string email)
        {
            return _dbContext.Users.Any(user => user.Email.Equals(email));
        }

        public User GetUserByEmail(string email) => _dbContext.Users.First(user => user.Email.Equals(email));
    }
}

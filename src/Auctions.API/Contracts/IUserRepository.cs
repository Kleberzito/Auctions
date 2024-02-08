using Auctions.API.Entities;

namespace Auctions.API.Contracts
{
    public interface IUserRepository
    {
        bool ExistUserWithEMail(string email);
        User GetUserByEmail(string email);
    }
}

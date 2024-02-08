using Auctions.API.Entities;
using Auctions.API.Repositories;

namespace Auctions.API.Services
{
    public class LoggedUser
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public LoggedUser(IHttpContextAccessor httpContext) 
        {
            _httpContextAccessor = httpContext;
        }

        public User User()
        {
            var repository = new AuctionDbContext();

            var token = TokenOnResquest();
            var email = FrontBase64String(token);

            return repository.Users.First(user => user.Email.Equals(email));
        }

        private string TokenOnResquest()
        {
            var authetication = _httpContextAccessor.HttpContext!.Request.Headers.Authorization.ToString();

            return authetication["Bearer ".Length..];
        }

        private string FrontBase64String(string base64)
        {
            var data = Convert.FromBase64String(base64);

            return System.Text.Encoding.UTF8.GetString(data);
        }
    }
}

using Auctions.API.Contracts;
using Auctions.API.Entities;

namespace Auctions.API.Services
{
    public class LoggedUser : ILoggedUser
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IUserRepository _repository;
        public LoggedUser(IHttpContextAccessor httpContext, IUserRepository repository) 
        {
            _httpContextAccessor = httpContext;
            _repository = repository;
        }

        public User User()
        {
            var token = TokenOnResquest();
            var email = FrontBase64String(token);

            return _repository.GetUserByEmail(email);
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

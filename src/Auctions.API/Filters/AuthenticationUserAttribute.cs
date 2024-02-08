using Auctions.API.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Reflection.PortableExecutable;

namespace Auctions.API.Filter
{
    public class AuthenticationUserAttribute : AuthorizeAttribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
           try
            {
                var token = TokenOnResquest(context.HttpContext);

                var repository = new AuctionDbContext();

                var email = FrontBase64String(token);

                var exist = repository.Users.Any(user => user.Email.Equals(email));

                if (exist == false)
                {
                    context.Result = new UnauthorizedObjectResult("E-mail not valid");
                }
            }
            catch (Exception ex)
            {
                context.Result = new UnauthorizedObjectResult(ex.Message);
            }
        }

        private string TokenOnResquest(HttpContext context) 
        {
            var authetication = context.Request.Headers.Authorization.ToString();

            if(string.IsNullOrEmpty(authetication)) 
            {
                throw new Exception("Token is missing");
            }

            return authetication["Bearer ".Length..];
        }

        private string FrontBase64String(string base64)
        {
            var data = Convert.FromBase64String(base64);

            return System.Text.Encoding.UTF8.GetString(data);
        }
    }
}

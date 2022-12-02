using OrdersDomain.Core.Aggregates.Entities.Users;
using System.Security.Claims;

namespace CleanOrders.API.Authorization
{
    public class UserService
    {
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly IConfiguration _configuration;

        public UserService(IHttpContextAccessor contextAccessor, IConfiguration configuration)
        {
            _contextAccessor = contextAccessor;
            _configuration = configuration;
        }



        public LoggedInUser GetCurrentUser()
        {
            var identity = _contextAccessor.HttpContext.User.Identity as ClaimsIdentity;
            if (identity != null)
            {
                var userClaims = identity.Claims;
                return new LoggedInUser
                (
                    userClaims.FirstOrDefault(u => u.Type == ClaimTypes.Actor).Value,
                    userClaims.FirstOrDefault(u => u.Type == ClaimTypes.NameIdentifier).Value,
                    userClaims.FirstOrDefault(u => u.Type == ClaimTypes.Role).Value
                );
            }
            return null;
        }
    }
}

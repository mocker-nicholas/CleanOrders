using CleanOrders.Application.Interfaces;
using CleanOrders.Infrastructure.Data;
using Microsoft.IdentityModel.Tokens;
using OrdersDomain.Core.Aggregates.Entities.Users;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace CleanOrders.API.Authorization
{
    public class UserService : IUserService
    {
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly IConfiguration _configuration;
        private readonly ApplicationContext _context;

        public UserService(IHttpContextAccessor contextAccessor, IConfiguration configuration, ApplicationContext context)
        {
            _contextAccessor = contextAccessor;
            _configuration = configuration;
            _context = context;
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

        public User Authenticate(UserLogin userLogin)
        {
            var user = _context.Users.FirstOrDefault(x => x.Email == userLogin.Email && x.Password == userLogin.Password);
            if (user == null)
            {
                return null;
            }
            return user;
        }

        public string Generate(User user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.Email),
                new Claim(ClaimTypes.Actor, user.Id),
                new Claim(ClaimTypes.Role, user.RoleId.ToString()),
            };
            var token = new JwtSecurityToken(
                _configuration["Jwt:Issuer"],
                _configuration["Jwt:Audience"],
                claims,
                notBefore: DateTime.Now,
                expires: DateTime.Now.AddMinutes(60),
                signingCredentials: credentials
           );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}

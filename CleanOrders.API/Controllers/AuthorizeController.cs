using CleanOrders.Application.Interfaces;
using CleanOrders.Infrastructure.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OrdersDomain.Core.Aggregates.Entities.Users;

namespace CleanOrders.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorizeController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly ApplicationContext _context;
        private readonly IUserService _userService;
        public AuthorizeController(IConfiguration configuration, ApplicationContext context, IUserService userService)
        {
            _configuration = configuration;
            _context = context;
            _userService = userService;
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Login([FromBody] UserLogin userLogin)
        {
            var user = _userService.Authenticate(userLogin);
            if (user == null)
            {
                return NotFound("Username or password incorrect");
            }
            var token = _userService.Generate(user);
            return Ok(token);
        }
    }
}

using Microsoft.AspNetCore.Mvc;

namespace CleanOrders.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : Controller
    {
        [HttpGet]
        public async Task<IActionResult> RegisterUser()
        {
            return Ok("Hey you got me");
        }
    }
}

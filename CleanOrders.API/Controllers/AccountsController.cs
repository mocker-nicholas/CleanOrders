using CleanOrders.Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;

namespace CleanOrders.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public AccountsController(ApplicationContext context)
        {
            _context = context;
        }

        //[HttpPost]
        //public async Task<>
    }
}

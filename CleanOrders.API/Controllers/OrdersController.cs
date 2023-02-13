using CleanOrders.Application.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CleanOrders.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IUserService _userService;
        public OrdersController(IMediator mediator, IUserService userService)
        {
            _mediator = mediator;
            _userService = userService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrder()
        {
            return Ok("Create an order");
        }

        [HttpGet]
        public async Task<IActionResult> GetAllOrders()
        {
            return Ok("Get all orders");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrderById()
        {
            return Ok("Get order by Id");
        }

    }
}

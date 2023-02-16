using CleanOrders.Application.Commands.Orders;
using CleanOrders.Application.Common.Dtos.Orders;
using CleanOrders.Application.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using OrdersDomain.Core.Aggregates.Entities.Users;

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
        public async Task<IActionResult> CreateOrder(CreateOrderCommand command)
        {
            // Validate Order is being made for same account as logged in user
            LoggedInUser user = _userService.GetCurrentUser();
            if (user.AccountId != command.AccountId)
                return BadRequest(new CreateOrderResponse("error", "invalid account Id"));

            return Ok(await _mediator.Send(command));
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

using CleanOrders.Application.Commands.Accounts;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CleanOrders.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly IMediator _mediator;
        public AccountsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateAccount(CreateAccountCommand command)
        {
            return Ok(await _mediator.Send(command));
        }
    }
}

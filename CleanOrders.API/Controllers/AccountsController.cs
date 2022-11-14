using CleanOrders.Application.Commands.Accounts;
using CleanOrders.Application.Queries.Accounts;
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
        [HttpGet]
        public async Task<IActionResult> GetAllAccounts()
        {
            return Ok(await _mediator.Send(new GetAllAccountsQuery()));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAccountById(string Id)
        {
            return Ok(await _mediator.Send(new GetAccountByIdQuery(Id)));
        }

        [HttpPost]
        public async Task<IActionResult> CreateAccount(CreateAccountCommand command)
        {
            return Ok(await _mediator.Send(command));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAccount(string id)
        {
            return Ok(await _mediator.Send(new DeleteAccountCommand { Id = id }));
        }
    }
}

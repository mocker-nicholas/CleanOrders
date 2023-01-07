using CleanOrders.API.ApiDtos.Accounts;
using CleanOrders.Application.Commands.Accounts;
using CleanOrders.Application.Interfaces;
using CleanOrders.Application.Queries.Accounts;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OrdersDomain.Core.Aggregates.Entities.Users;

namespace CleanOrders.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IUserService _userService;
        public AccountsController(IMediator mediator, IUserService userService)
        {
            _mediator = mediator;
            _userService = userService;
        }
        [HttpGet]
        [Authorize(Policy = "Super")]
        public async Task<IActionResult> GetAllAccounts()
        {
            return Ok(await _mediator.Send(new GetAllAccountsQuery()));
        }

        [HttpGet("{id}")]
        [Authorize(Policy = "AllUsers")]
        public async Task<IActionResult> GetAccountById(string Id)
        {
            LoggedInUser user = _userService.GetCurrentUser();
            return Ok(await _mediator.Send(new GetAccountByIdQuery(Id, user)));
        }

        [HttpPost]
        [Authorize(Policy = "Super")]
        public async Task<IActionResult> CreateAccount(CreateAccountCommand command)
        {
            return Ok(await _mediator.Send(command));
        }

        [HttpPut("{id}")]
        [Authorize(Policy = "Super")]
        public async Task<IActionResult> UpdateAccount(string id, ApiAccountDto request)
        {
            UpdateAccountCommand command = new(
                id,
                request.BusinessName,
                request.Email,
                request.StreetAddress1,
                request.StreetAddress2,
                request.Country,
                request.City,
                request.State,
                request.PostalCode
            );
            return Ok(await _mediator.Send(command));
        }

        [HttpDelete("{id}")]
        [Authorize(Policy = "Super")]
        public async Task<IActionResult> DeleteAccount(string id)
        {
            return Ok(await _mediator.Send(new DeleteAccountCommand(id)));
        }
    }
}

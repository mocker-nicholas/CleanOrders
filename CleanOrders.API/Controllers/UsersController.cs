using CleanOrders.Application.Commands.Users;
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
    public class UsersController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IUserService _userService;
        public UsersController(IMediator mediator, IUserService userService)
        {
            _mediator = mediator;
            _userService = userService;
        }

        [HttpPost]
        public async Task<IActionResult> RegisterUser(CreateUserCommand command)
        {
            return Ok(await _mediator.Send(command));
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetAllUsers()
        {
            LoggedInUser user = _userService.GetCurrentUser();
            return Ok(await _mediator.Send(new GetAllUsersQuery(user.AccountId)));
        }
    }
}

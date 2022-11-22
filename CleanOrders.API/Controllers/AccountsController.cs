﻿using CleanOrders.Application.Commands.Accounts;
using CleanOrders.Application.Queries.Accounts;
using CleanOrders.Infrastructure.Data;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CleanOrders.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ApplicationContext _context;
        public AccountsController(IMediator mediator, ApplicationContext context)
        {
            _mediator = mediator;
            _context = context;
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
            //var result = _context.Accounts.Where(x => x.Id == Id).Include(x => x.Users);
            //return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAccount(CreateAccountCommand command)
        {
            return Ok(await _mediator.Send(command));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAccount(string id, UpdateAccountCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }
            return Ok(await _mediator.Send(command));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAccount(string id)
        {
            return Ok(await _mediator.Send(new DeleteAccountCommand { Id = id }));
        }
    }
}

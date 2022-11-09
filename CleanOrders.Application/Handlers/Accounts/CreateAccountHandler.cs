using CleanOrders.Application.Commands.Accounts;
using CleanOrders.Application.Common.Dtos.Accounts;
using CleanOrders.Application.Dtos.Accounts;
using CleanOrders.Application.Interfaces.Repositories;
using CleanOrders.Infrastructure.Data;
using FluentValidation.Results;
using MediatR;
using OrdersDomain.Core.Aggregates.Entities.Accounts;

namespace CleanOrders.Application.Handlers.Accounts
{
    public class CreateAccountHandler : IRequestHandler<CreateAccountCommand, CreateAccountResponse>
    {
        private readonly ApplicationContext _context;
        private readonly IAccountRepositoryAsync _accountRepositoryAsync;
        public CreateAccountHandler(ApplicationContext context, IAccountRepositoryAsync accountRepository)
        {
            _context = context;
            _accountRepositoryAsync = accountRepository;
        }

        public async Task<CreateAccountResponse> Handle(CreateAccountCommand request, CancellationToken cancellationToken)
        {
            CreateAccountCommandValidator Validator = new();
            ValidationResult result = Validator.Validate(request);
            if (result.IsValid)
            {
                Account account = new(request.Password, request.Email, request.Name);
                await _context.Accounts.AddAsync(account, cancellationToken);
                await _context.SaveChangesAsync(cancellationToken);
                AccountDto newAccount = new(account);
                return new CreateAccountResponse(newAccount);
            }
            return new CreateAccountResponse(result.ToString());
        }
    }
}

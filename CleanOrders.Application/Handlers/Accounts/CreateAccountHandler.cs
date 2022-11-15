using CleanOrders.Application.Commands.Accounts;
using CleanOrders.Application.Common.Dtos.Accounts;
using CleanOrders.Application.Dtos.Accounts;
using CleanOrders.Application.Interfaces.Repositories;
using FluentValidation.Results;
using MediatR;
using OrdersDomain.Core.Aggregates.Entities.Accounts;

namespace CleanOrders.Application.Handlers.Accounts
{
    public class CreateAccountHandler : IRequestHandler<CreateAccountCommand, CreateAccountResponse>
    {
        private readonly IAccountRepositoryAsync _accountRepositoryAsync;
        public CreateAccountHandler(IAccountRepositoryAsync accountRepository)
        {
            _accountRepositoryAsync = accountRepository;
        }

        public async Task<CreateAccountResponse> Handle(CreateAccountCommand request, CancellationToken cancellationToken)
        {
            CreateAccountCommandValidator Validator = new();
            ValidationResult result = Validator.Validate(request);
            if (!result.IsValid)
            {
                return new CreateAccountResponse(result.ToString());
            }

            bool emailIsUnique = await _accountRepositoryAsync.EmailIsUnique(request.Email);
            if (!emailIsUnique)
            {
                return new CreateAccountResponse("An account for that address already exists");
            }

            Account account = new(request.Name, request.Email, request.Password);
            await _accountRepositoryAsync.AddAsync(account);
            AccountDto newAccount = new(account);
            return new CreateAccountResponse(newAccount);
        }
    }
}

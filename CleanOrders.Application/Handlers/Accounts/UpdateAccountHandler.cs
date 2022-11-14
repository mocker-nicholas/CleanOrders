using CleanOrders.Application.Commands.Accounts;
using CleanOrders.Application.Common.Dtos.Accounts;
using CleanOrders.Application.Interfaces.Repositories;
using FluentValidation.Results;
using MediatR;
using OrdersDomain.Core.Aggregates.Entities.Accounts;

namespace CleanOrders.Application.Handlers.Accounts
{
    public class UpdateAccountHandler : IRequestHandler<UpdateAccountCommand, UpdateAccountResponse>
    {
        private readonly IAccountRepositoryAsync _accountRepositoryAsync;
        public UpdateAccountHandler(IAccountRepositoryAsync accountRepositoryAsync)
        {
            _accountRepositoryAsync = accountRepositoryAsync;
        }

        public async Task<UpdateAccountResponse> Handle(UpdateAccountCommand request, CancellationToken cancellationToken)
        {
            UpdateAccountCommandValidator Validator = new();
            ValidationResult ValidationResult = Validator.Validate(request);
            if (!ValidationResult.IsValid)
            {
                return new UpdateAccountResponse(ValidationResult.ToString());
            }
            bool emailIsUnique = await _accountRepositoryAsync.EmailIsUnique(request.Email);
            if (!emailIsUnique)
            {
                return new UpdateAccountResponse("An account for that address already exists");
            }
            Account accountToUpdate = await _accountRepositoryAsync.GetByIdAsync(request.Id);
            if (accountToUpdate == null)
            {
                return new UpdateAccountResponse("No Account was found");
            }
            Account account = await _accountRepositoryAsync.UpdateAsync(accountToUpdate);
            AccountDto result = new(account);
            return new UpdateAccountResponse(result);

        }
    }
}

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
            Account accountToUpdate = await _accountRepositoryAsync.GetByIdAsync(request.Id);
            if (accountToUpdate == null)
            {
                return new UpdateAccountResponse("No Account was found");
            }
            bool emailIsUnique = await _accountRepositoryAsync.EmailIsUnique(request.Email);
            if (!emailIsUnique && request.Email != accountToUpdate.Email)
            {
                return new UpdateAccountResponse("An account for that address already exists");
            }

            accountToUpdate.Name = request.Name;
            accountToUpdate.Email = request.Email;
            accountToUpdate.StreetAddress1 = request.StreetAddress1;
            accountToUpdate.StreetAddress2 = request.StreetAddress2;
            accountToUpdate.City = request.City;
            accountToUpdate.Country = request.Country;
            accountToUpdate.State = request.State;
            accountToUpdate.PostalCode = request.PostalCode;

            Account account = await _accountRepositoryAsync.UpdateAsync(accountToUpdate);
            AccountDto result = new(account);
            return new UpdateAccountResponse(result);
        }
    }
}

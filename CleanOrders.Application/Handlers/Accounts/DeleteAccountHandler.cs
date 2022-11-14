using CleanOrders.Application.Commands.Accounts;
using CleanOrders.Application.Common.Dtos.Accounts;
using CleanOrders.Application.Dtos.Accounts;
using CleanOrders.Application.Interfaces.Repositories;
using MediatR;
using OrdersDomain.Core.Aggregates.Entities.Accounts;

namespace CleanOrders.Application.Handlers.Accounts
{
    public class DeleteAccountHandler : IRequestHandler<DeleteAccountCommand, DeleteAccountResponse>
    {
        private readonly IAccountRepositoryAsync _accountRepositoryAsync;
        public DeleteAccountHandler(IAccountRepositoryAsync accountRepositoryAsync)
        {
            _accountRepositoryAsync = accountRepositoryAsync;
        }

        public async Task<DeleteAccountResponse> Handle(DeleteAccountCommand request, CancellationToken cancellationToken)
        {
            try
            {
                Account account = await _accountRepositoryAsync.DeleteAsync(request.Id);
                if (account == null)
                    return new DeleteAccountResponse("No Account was found");
                AccountDto result = new(account);
                return new DeleteAccountResponse(result);
            }
            catch (Exception ex)
            {
                throw new Exception("Error deleting account", ex);
            }
        }
    }
}

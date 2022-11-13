using CleanOrders.Application.Common.Dtos.Accounts;
using CleanOrders.Application.Interfaces.Repositories;
using CleanOrders.Application.Queries.Accounts;
using MediatR;
using OrdersDomain.Core.Aggregates.Entities.Accounts;

namespace CleanOrders.Application.Handlers.Accounts
{
    public class GetAccountByIdHandler : IRequestHandler<GetAccountByIdQuery, GetAccountByIdResponse>
    {
        private readonly IAccountRepositoryAsync _accountRepositoryAsync;

        public GetAccountByIdHandler(IAccountRepositoryAsync accountsRepository)
        {
            _accountRepositoryAsync = accountsRepository;
        }
        public async Task<GetAccountByIdResponse> Handle(GetAccountByIdQuery request, CancellationToken cancellationToken)
        {
            Account account = await _accountRepositoryAsync.GetByIdAsync(request.Id);
            if (account == null)
            {
                return new GetAccountByIdResponse("No account was found");
            }
            AccountDto result = new(account);
            return new GetAccountByIdResponse(result);
        }
    }
}

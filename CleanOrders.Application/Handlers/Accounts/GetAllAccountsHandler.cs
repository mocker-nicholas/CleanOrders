using CleanOrders.Application.Common.Dtos.Accounts;
using CleanOrders.Application.Interfaces.Repositories;
using CleanOrders.Application.Queries.Accounts;
using MediatR;
using OrdersDomain.Core.Aggregates.Entities.Accounts;

namespace CleanOrders.Application.Handlers.Accounts
{
    public class GetAllAccountsHandler : IRequestHandler<GetAllAccountsQuery, GetAllAccountsResponse>
    {
        private readonly IAccountRepositoryAsync _accountsRepository;
        public GetAllAccountsHandler(IAccountRepositoryAsync accountsRepository)
        {
            _accountsRepository = accountsRepository;
        }

        public async Task<GetAllAccountsResponse> Handle(GetAllAccountsQuery request, CancellationToken cancellationToken)
        {
            IEnumerable<Account> accounts = await _accountsRepository.GetAllAsync();
            List<AccountDto> accountsList = new();
            foreach (Account account in accounts)
            {
                AccountDto dto = new AccountDto(account);
                accountsList.Add(dto);
            }
            return new GetAllAccountsResponse(accountsList);
        }
    }
}

using CleanOrders.Application.Interfaces;
using CleanOrders.Application.Interfaces.Repositories;
using CleanOrders.Infrastructure.Data;
using OrdersDomain.Core.Aggregates.Entities.Accounts;

namespace CleanOrders.Infrastructure.Repositories
{
    public class AccountRepository : IAccountRepositoryAsync
    {
        private readonly ApplicationContext _context;
        public AccountRepository(ApplicationContext context)
        {
            _context = context;
        }
        public async Task<Account> AddAsync(Account account)
        {
            await _context.Accounts.AddAsync(account);
            await _context.SaveChangesAsync();
            return account;

        }

        Task IGenericRepositoryAsync<Account>.DeleteAsync(Account entity)
        {
            throw new NotImplementedException();
        }

        bool IAccountRepositoryAsync.EmailIsUnique(string email)
        {
            throw new NotImplementedException();
        }

        Task<IReadOnlyList<Account>> IGenericRepositoryAsync<Account>.GetAllAsync()
        {
            throw new NotImplementedException();
        }

        Task<Account> IGenericRepositoryAsync<Account>.GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<IReadOnlyList<Account>> IGenericRepositoryAsync<Account>.GetPagedReponseAsync(int pageNumber, int pageSize)
        {
            throw new NotImplementedException();
        }

        Task IGenericRepositoryAsync<Account>.UpdateAsync(Account entity)
        {
            throw new NotImplementedException();
        }
    }
}

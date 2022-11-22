using CleanOrders.Application.Interfaces.Repositories;
using CleanOrders.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
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
            try
            {
                await _context.Accounts.AddAsync(account);
                await _context.SaveChangesAsync();
            }
            catch
            {
                throw new Exception("Error adding account");
            }
            return account;

        }

        public async Task<Account> DeleteAsync(string id)
        {
            Account? account = await _context.Accounts.FindAsync(id);
            if (account != null)
            {
                _context.Accounts.Remove(account);
                await _context.SaveChangesAsync();
            }
            return account;
        }

        public async Task<bool> EmailIsUnique(string email)
        {
            List<Account> accounts = await _context.Accounts.Where(x => x.Email == email).ToListAsync();
            bool result = accounts.Count == 0;
            return result;
        }

        public async Task<IReadOnlyList<Account>> GetAllAsync()
        {
            List<Account> accounts = await _context.Accounts.ToListAsync();
            return accounts;
        }

        public async Task<Account> GetByIdAsync(string id)
        {
            //Account? account = await _context.Accounts.FindAsync(id);
            IQueryable<Account> account = _context.Accounts.Where(a => a.Id == id).Include(a => a.Users);
            return account.First();
        }

        public Task<IReadOnlyList<Account>> GetPagedReponseAsync(int pageNumber, int pageSize)
        {
            throw new NotImplementedException();
        }

        public async Task<Account> UpdateAsync(Account account)
        {
            _context.Accounts.Update(account);
            await _context.SaveChangesAsync();
            return account;
        }
    }
}

using CleanOrders.Application.Interfaces.Repositories;
using CleanOrders.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using OrdersDomain.Core.Aggregates.Entities.Users;

namespace CleanOrders.Infrastructure.Repositories
{
    public class UsersRepository : IUserRepositoryAsync
    {
        private readonly ApplicationContext _context;

        public UsersRepository(ApplicationContext context)
        {
            _context = context;
        }
        public async Task<User> AddAsync(User user)
        {
            try
            {
                await _context.Users.AddAsync(user);
                await _context.SaveChangesAsync();
            }
            catch
            {
                throw new Exception("Error adding User");
            }
            return user;
        }

        public Task<IReadOnlyList<User>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<User> GetByIdAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyList<User>> GetPagedReponseAsync(int pageNumber, int pageSize)
        {
            throw new NotImplementedException();
        }

        public Task<User> UpdateAsync(User entity)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> EmailIsUnique(string email)
        {
            List<User> users = await _context.Users.Where(x => x.Email == email).ToListAsync();
            bool result = users.Count == 0;
            return result;
        }
    }
}

using CleanOrders.Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using OrdersDomain.Core.Aggregates.Entities.Users;

namespace CleanOrders.Infrastructure.Repositories
{
    public class UsersRepository : IGenericRepositoryAsync<User>
    {
        private readonly DbContext _context;
        public async Task<User> AddAsync(User user)
        {
            try
            {
                //await _context.Users.AddAsync(user);
                await _context.SaveChangesAsync();
            }
            catch
            {
                throw new Exception("Error adding account");
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
    }
}

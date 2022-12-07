using CleanOrders.Application.Common.Dtos.Users;
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
        public async Task<List<UserDto>> GetAllAsync(string AccountId)
        {
            try
            {
                List<User> users = await _context.Users.Where(u => u.AccountId == AccountId).ToListAsync();
                List<UserDto> result = new();
                foreach (var user in users)
                {
                    var dto = new UserDto(user);
                    result.Add(dto);
                }
                return result;
            }
            catch
            {
                throw new Exception("Error fetching Users");
            }
        }

        public async Task<bool> EmailIsUnique(string email)
        {
            List<User> users = await _context.Users.Where(x => x.Email == email).ToListAsync();
            bool result = users.Count == 0;
            return result;
        }
    }
}

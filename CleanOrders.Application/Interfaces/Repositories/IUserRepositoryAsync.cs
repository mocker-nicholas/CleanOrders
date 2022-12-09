using CleanOrders.Application.Common.Dtos.Users;
using OrdersDomain.Core.Aggregates.Entities.Users;

namespace CleanOrders.Application.Interfaces.Repositories
{
    public interface IUserRepositoryAsync
    {
        Task<User> AddAsync(User user);
        Task<List<UserDto>> GetAllAsync(string AccountId);
        Task<User> UpdateAsync(User User);
        Task<User> GetByIdAsync(string UserId);
        Task<bool> EmailIsUnique(string email);
    }
}
